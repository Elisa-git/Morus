using Application;
using Application.Interfaces;
using AutoMapper;using Core.Exceptions;
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
    [Authorize]
    public class AreaComumController : MorusController
    {
        private readonly IAreaComumApplication _areaComumApplication;
        private readonly IAreaComumService areaComumService;
        private readonly IMapper mapper;

        public AreaComumController(IAreaComumApplication areaComumApplication, IAreaComumService areaComumService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _areaComumApplication = areaComumApplication;
            this.areaComumService = areaComumService;
            this.mapper = mapper;
        }

        [Produces("application/json")]
        [HttpPost("/api/CadastrarAreaComum")]
        public async Task<IActionResult> CadastrarAreaComum(AreaComumRequest areaComumRequest)
        {
            try
            {
                var areaComum = mapper.Map<AreaComum>(areaComumRequest);
                await _areaComumApplication.CadastrarAreaComum(areaComum);

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

        [Produces("application/json")]
        [HttpPut("/api/EditarAreaComum")]
        public async Task<IActionResult> AtualizarAreaComum(AreaComumRequest areaComumRequest)
        {
            try
            {
                if (areaComumRequest.Id == null || areaComumRequest.Id == 0)
                {
                    _notificador.Notificar("Informe o Id");
                    throw new ValidacaoException();
                }

                var areaComumMapeada = mapper.Map<AreaComum>(areaComumRequest);
                await _areaComumApplication.AtualizarAreaComum(areaComumMapeada);

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

        [Produces("application/json")]
        [HttpDelete("/api/DeletarAreaComum/{id:int}")]
        public async Task<IActionResult> DeletarAreaComum(int id)
        {
            try
            {
                await _areaComumApplication.DeletarAreaComum(id);

                return CustomResponse(200, true);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarAreasComuns")]
        public async Task<IActionResult> ListarAreasComuns()
        {
            try
            {
                var areaComum = await _areaComumApplication.ListarAreaComum();
                var areaComumMapeada = mapper.Map<List<AreaComumRequest>>(areaComum);

                return CustomResponse(areaComumMapeada != null ? 200 : 404, true, areaComumMapeada);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ObterPorId/{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var areaComum = await _areaComumApplication.ObterPorId(id);
                var areaComumMapeada = mapper.Map<AreaComumRequest>(areaComum);

                return CustomResponse(areaComumMapeada != null ? 200 : 404, true, areaComumMapeada);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }
    }
}
