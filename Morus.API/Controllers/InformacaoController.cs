using Application;
using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacaoController : MorusController
    {
        private readonly IMapper mapper;
        private readonly IInformacaoRepositorio informaoRepositorio;
        private readonly IInformacaoService informacaoService;
        private readonly IInformacaoApplication informacaoApplication;

        public InformacaoController(IMapper mapper, IInformacaoRepositorio informaoRepositorio, IInformacaoService informacaoService, INotificador notificador, IInformacaoApplication informacaoApplication) : base(notificador)
        {
            this.mapper = mapper;
            this.informaoRepositorio = informaoRepositorio;
            this.informacaoService = informacaoService;
            this.informacaoApplication = informacaoApplication;
        }

        [Produces("application/json")]
        [HttpPost("/api/CadastrarInformacao")]
        [Authorize]
        public async Task<IActionResult> CadastrarInformacao(InformacaoRequest informacaoRequest)
        {
            try
            {
                var informacaoMapeada = mapper.Map<Informacao>(informacaoRequest);
                await informacaoApplication.CadastrarInformacao(informacaoMapeada);

                return CustomResponse(200, true);
            } 
            catch(ValidacaoException)
            {
                return CustomResponse(400, false);
            }
            catch(Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarInformacao")]
        public async Task<IActionResult> AtualizarInformacao(InformacaoRequest informacaoRequest)
        {
            try
            {
                var informacaoMapeada = mapper.Map<Informacao>(informacaoRequest);
                await informacaoApplication.AtualizarInformacao(informacaoMapeada);


                return CustomResponse(200, true);
            }
            catch (ValidacaoException)
            {
                return CustomResponse(400, false);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListarInformacao")]
        public async Task<IActionResult> ListarInformacao()
        {
            try
            {
                var informacoes = await informacaoApplication.ListarInformacoesCondominio();
                var informacaoMapeada = mapper.Map<List<InformacaoRequest>>(informacoes);

                return CustomResponse(informacaoMapeada != null ? 200 : 404, true, informacaoMapeada);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarInformacao/{id:int}")]
        public async Task<IActionResult> DeletarInformacao(int id)
        {
            try
            {
                await informacaoApplication.DeletarInformacao(id);

                return CustomResponse(200, true);
            }
            catch(InvalidOperationException)
            {
                return CustomResponse(403, false);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            return "54181da4-4e19-45df-bfa4-8f339c3bb46b";
        }
    }
}
