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
    public class AreaComumController : MorusController
    {
        private readonly IAreaComumRepositorio areaComumRepositorio;
        private readonly IAreaComumService areaComumService;
        private readonly IMapper mapper;

        public AreaComumController(IAreaComumRepositorio areaComumRepositorio, IAreaComumService areaComumService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            this.areaComumRepositorio = areaComumRepositorio;
            this.areaComumService = areaComumService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarAreaComum")]
        public async Task<IActionResult> CadastrarAreaComum(AreaComumRequest areaComumRequest)
        {
            try
            {
                var areaComum = mapper.Map<AreaComum>(areaComumRequest);
                await areaComumService.CadastrarAreaComum(areaComum);

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

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/EditarAreaComum")]
        public async Task<IActionResult> AtualizarAreaComum(AreaComumRequest areaComumRequest)
        {
            try
            {
                var areaComumMapeada = mapper.Map<AreaComum>(areaComumRequest);
                await areaComumService.AtualizarAreaComum(areaComumMapeada);

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

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarAreaComum")]
        public async Task<IActionResult> DeletarAreaComum(AreaComumRequest areaComumRequest)
        {
            try
            {
                var areaComum = mapper.Map<AreaComum>(areaComumRequest);
                areaComumRepositorio.Delete(areaComum);

                return CustomResponse(200, true);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarAreasComuns")]
        public async Task<IActionResult> ListarAreasComuns()
        {
            try
            {
                var areaComum = await areaComumService.ListarAreaComum();
                var areaComumMapeada = mapper.Map<List<AreaComumRequest>>(areaComum);

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
