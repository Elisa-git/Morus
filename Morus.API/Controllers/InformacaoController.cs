using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacaoController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IInformacaoRepositorio informaoRepositorio;
        private readonly IInformacaoService informacaoService;

        public InformacaoController(IMapper mapper, IInformacaoRepositorio informaoRepositorio, IInformacaoService informacaoService)
        {
            this.mapper = mapper;
            this.informaoRepositorio = informaoRepositorio;
            this.informacaoService = informacaoService;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarInformacao")]
        public async Task<List<Notifies>> CadastrarInformacao(InformacaoRequest informacaoRequest)
        {
            informacaoRequest.UserId = await RetornarIdUsuarioLogado();
            var informacaoMapeada = mapper.Map<Informacao>(informacaoRequest);
            await informaoRepositorio.Add(informacaoMapeada);
            return informacaoMapeada.ListaNotificacoes;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarInformacao")]
        public async Task<List<Notifies>> AtualizarInformacao(InformacaoRequest informacaoRequest)
        {
            var informacaoMapeada = mapper.Map<Informacao>(informacaoRequest);
            await informaoRepositorio.Update(informacaoMapeada);
            return informacaoMapeada.ListaNotificacoes;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarInformacao")]
        public async Task<List<InformacaoRequest>> ListarInformacao()
        {
            var informacao = await informaoRepositorio.List();
            var informacaoMapeada = mapper.Map<List<InformacaoRequest>>(informacao);
            return informacaoMapeada;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarInformacao")]
        public async Task<List<Notifies>> DeletarInformacao(InformacaoRequest message)
        {
            var informacaoMapeada = mapper.Map<Informacao>(message);
            await informaoRepositorio.Delete(informacaoMapeada);
            return informacaoMapeada.ListaNotificacoes;
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            return "54181da4-4e19-45df-bfa4-8f339c3bb46b";
        }
    }
}
