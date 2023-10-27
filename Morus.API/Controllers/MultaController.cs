using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultaController : MorusController
    {
        private readonly IMulta _multaRepositorio;
        private readonly IMultaService multaService;
        private readonly IMapper mapper;
        private readonly IMulta _IMulta;
        public MultaController(MultaRepositorio multaRepositorio, IMultaService multaService, IMapper mapper, IMulta IMulta, INotificador notificador) : base(notificador)
        {
            _multaRepositorio = multaRepositorio;
            this.multaService = multaService;
            this.mapper = mapper;
            _IMulta = IMulta;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarMulta")]
        public async Task<IActionResult> CadastrarMulta(MultaRequest multaRequest)
        {
            try
            {
                var multaMapeada = mapper.Map<Multa>(multaRequest);
                await multaService.SalvarMulta(multaMapeada);

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
        [HttpPut("/api/AtualizarMulta")]
        public async Task<IActionResult> AtualizarMulta(MultaRequest multaRequest)
        {
            try
            {
                var multaMapeada = mapper.Map<Multa>(multaRequest);
                await multaService.AtualizarMulta(multaMapeada);

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
        [HttpDelete("/api/DeletarMulta")]
        public async Task<IActionResult> DeletarMulta(MultaRequest multaRequest)
        {
            try
            {
                var multaMap = mapper.Map<Multa>(multaRequest);
                await _multaRepositorio.Delete(multaMap);
                
                return CustomResponse(200, true);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        //[AllowAnonymous]
        //[Produces("application/json")]
        //[HttpGet("/api/GetMultaById")]
        //public async Task<Multa> ProcurarMulta(Multa multaRequest)
        //{
        //    multaRequest = await _IMulta.GetEntityById(multaRequest.Id);
        //    var multaMap = mapper.Map<Multa>(multaRequest);
        //    return multaMap;
        //}

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarMultas")]
        public async Task<IActionResult> ListarMultas()
        {
            try
            {
                var multa = await multaService.ListarMultas();
                var multaMap = mapper.Map<List<Multa>>(multa);

                return CustomResponse(multaMap != null ? 200 : 404, true, multaMap);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }
    }
}
