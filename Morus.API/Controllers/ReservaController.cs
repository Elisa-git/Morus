using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : MorusController
    {
        private readonly IMapper mapper;
        private readonly IReservaService reservaService;

        public ReservaController(IMapper mapper, IReservaService reservaService, INotificador notificador) : base(notificador)
        {
            this.mapper = mapper;
            this.reservaService = reservaService;
        }

        [Produces("application/json")]
        [HttpPost("/api/CadastrarReserva")]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarReserva(ReservaRequest reservaRequest)
        {
            try
            {
                reservaRequest.UserId = await RetornarIdUsuarioLogado();
                var reservaMapeada = mapper.Map<Reserva>(reservaRequest);
                await reservaService.CadastrarReserva(reservaMapeada);

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
        [HttpPut("/api/AtualizarReserva")]
        [AllowAnonymous]
        public async Task<IActionResult> AtualizarReserva(ReservaRequest reservaRequest)
        {
            try
            {
                var reservaMapeada = mapper.Map<Reserva>(reservaRequest);
                await reservaService.AtualizarReserva(reservaMapeada, reservaRequest.UserId);

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
        [HttpGet("/api/ListarReserva")]
        [AllowAnonymous]
        public async Task<IActionResult> ListarReserva()
        {
            try
            {
                var reserva = await reservaService.ListarReservas();
                var reservaMapeada = mapper.Map<List<Reserva>>(reserva);

                return CustomResponse(reservaMapeada != null ? 200 : 404, true, reservaMapeada);
            }
            catch(Exception e) 
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeletarReserva")]
        [AllowAnonymous]
        public async Task<IActionResult> DeletarReserva(ReservaRequest reservaRequest)
        {
            try
            {
                var reservaMapeada = mapper.Map<Reserva>(reservaRequest);
                await reservaService.DeletarReserva(reservaMapeada, reservaRequest.UserId);

                return CustomResponse(200, true);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            return "ebafef68-4f09-4fc5-834c-2b0871b770c0";
        }
    }
}
