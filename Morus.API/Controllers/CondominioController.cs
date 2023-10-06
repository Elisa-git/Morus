using AutoMapper;
using Core.Notificador;
using Domain.Entities;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : ControllerBase
    {
        private readonly CondominioRepositorio _condominioRepositorio;
        private readonly INotificador _notificador;
        private readonly IMapper mapper;

        public CondominioController(CondominioRepositorio condominioRepositorio, IMapper mapper, INotificador notificador)
        {
            _condominioRepositorio = condominioRepositorio;
            _notificador = notificador;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarCondominio")]
        public async Task<List<Notifies>> CadastrarCondominio(CondominioRequest condominioRequest)
        {
            //var condominioMapeado = mapper.Map<Condominio>(condominio);
            //return Ok(condominioService.SalvarCondominio(condominioMapeado));

            condominioRequest.UserId = await RetornarIdUsuarioLogado();
            var condominioMapeado = mapper.Map<Condominio>(condominioRequest);
            return null;
            //var mensagens = condominioMapeado.Validar();
            //if (mensagens.Any())
            //    mensagens.ForEach(m => _notificador.Notificar(new Notificacao(m)));




            //await _condominioRepositorio.Add(condominioMapeado);

            //return condominioMapeado.ListaNotificacoes;

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarCondominio")]
        public async Task<List<Notifies>> AtualizarCondominio(CondominioRequest condominioRequest)
        {
            var condominioMapeado = mapper.Map<Condominio>(condominioRequest);
            await _condominioRepositorio.Update(condominioMapeado);
            //return condominioMapeado.ListaNotificacoes;
            return null;
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            return "54181da4-4e19-45df-bfa4-8f339c3bb46b";
        }
    }
}


