using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncomendaController : MorusController
    {
        private readonly IMapper mapper;
        private readonly IEncomendaApplication _encomendaApplication;

        public EncomendaController(IMapper mapper, INotificador notificador, IEncomendaApplication encomendaApplication) : base(notificador)
        {
            _encomendaApplication = encomendaApplication;
            this.mapper = mapper;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarEncomenda")]
        public async Task<IActionResult> CadastrarEncomenda(EncomendaRequest encomendaRequest)
        {
            try
            {
                var encomendaMap = mapper.Map<Encomenda>(encomendaRequest);
                await _encomendaApplication.CadastrarEncomenda(encomendaMap); 
                
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

        [Authorize]
        [Produces("application/json")]
        [HttpPut("/api/EditarEncomenda")]
        public async Task<IActionResult> AtualizarEncomenda(EncomendaRequest encomendaRequest)
        {
            try
            {
                if (encomendaRequest.Id == null || encomendaRequest.Id == 0)
                {
                    _notificador.Notificar("Informe o Id");
                    throw new ValidacaoException();
                }

                var encomendaMap = mapper.Map<Encomenda>(encomendaRequest);
                await _encomendaApplication.AtualizarEncomenda(encomendaMap);

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

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarEncomenda/{id:int}")]
        public async Task<IActionResult> DeletarEncomenda(int id)
        {
            try
            {
                await _encomendaApplication.DeletarEncomenda(id);

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

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ObterEncomendaPorId/{id:int}")]
        public async Task<IActionResult> ObterEncomendaPorId(int id)
        {
            try
            {
                var encomenda = await _encomendaApplication.ObterPorId(id);

                return CustomResponse(encomenda != null ? 200 : 404, true, encomenda);
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

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListarEncomenda")]
        public async Task<IActionResult> ListarEncomenda()
        {
            try
            {
                var encomendas = await _encomendaApplication.ListarEncomendas();

                return CustomResponse(encomendas != null ? 200 : 404, true, encomendas);
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
    }
}
