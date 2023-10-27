using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces.InterfaceServices;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : MorusController
    {
        private readonly CondominioRepositorio _condominioRepositorio;
        private readonly ICondominioService _condominioService;
        private readonly IMapper mapper;

        public CondominioController(CondominioRepositorio condominioRepositorio, ICondominioService condominioService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _condominioRepositorio = condominioRepositorio;
            _condominioService = condominioService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarCondominio")]
        public async Task<IActionResult> CadastrarCondominio(CondominioRequest condominioRequest)
        {
            try
            {
                var condominioMapeado = mapper.Map<Condominio>(condominioRequest);
                await _condominioService.SalvarCondominio(condominioMapeado);
                return CustomResponse(200, true);
            }
            catch (Exception e)
            {
                return CustomResponse(500, false);
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarCondominio")]
        public async Task<IActionResult> AtualizarCondominio(CondominioRequest condominioRequest)
        {
            try
            {
                if (condominioRequest.Id == null || condominioRequest.Id == 0)
                {
                    _notificador.Notificar("Informe o Id");
                    throw new ValidacaoException();
                }

                var condominioMapeado = mapper.Map<Condominio>(condominioRequest);
                await _condominioService.AtualizarCondominio(condominioMapeado);

                return CustomResponse(200, true);
            }
            catch (ValidacaoException e)
            {
                return CustomResponse(400, false);
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


