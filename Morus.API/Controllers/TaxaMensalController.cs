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
    [Produces("application/json")]
    [ApiController]
    public class TaxaMensalController : MorusController
    {
        private readonly ITaxaMensalRepositorio taxaMensalRepositorio;
        private readonly ITaxaMensalService taxaMensalService;
        private readonly ITaxaMensalApplication taxaMensalApplication;
        private readonly IMapper mapper;

        public TaxaMensalController(ITaxaMensalRepositorio taxaMensalRepositorio, ITaxaMensalService taxaMensalService, IMapper mapper, INotificador notificador, ITaxaMensalApplication taxaMensalApplication) : base(notificador)
        {
            this.taxaMensalRepositorio = taxaMensalRepositorio;
            this.taxaMensalService = taxaMensalService;
            this.taxaMensalApplication = taxaMensalApplication;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpPost("/api/CadastrarTaxaMensal")]
        public IActionResult CadastrarTaxaMensal(TaxaMensalRequest taxaMensalRequest)
        {
            try
            {
                var taxaMensal = mapper.Map<TaxaMensal>(taxaMensalRequest);
                taxaMensalApplication.CadastrarTaxaMensal(taxaMensal);

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
        [HttpPut("/api/AtualizarTaxaMensal")]
        public async Task<IActionResult> AtualizarTaxaMensal(TaxaMensalRequest taxaMensalRequest)
        {
            try
            {
                if (taxaMensalRequest.Id == null || taxaMensalRequest.Id == 0)
                {
                    _notificador.Notificar("Informe o Id");
                    throw new ValidacaoException();
                }

                var taxaMensal = mapper.Map<TaxaMensal>(taxaMensalRequest);
                await taxaMensalApplication.AtualizarTaxaMensal(taxaMensal);

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
        [HttpDelete("/api/ExcluirTaxaMensal")]
        public async Task<IActionResult> ExcluirTaxaMensal(TaxaMensalRequest taxaMensalRequest)
        {
            try
            {
                var taxaMensal = mapper.Map<TaxaMensal>(taxaMensalRequest);
                taxaMensalRepositorio.Delete(taxaMensal);

                return CustomResponse(200, true);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [Authorize]
        [HttpGet("/api/ListarTaxaMensal")]
        public async Task<IActionResult> ListarTaxaMensal()
        {
            try
            {
                var taxaMensal = await taxaMensalService.ListarTaxaMensal();
                var taxaMensalMapeada = mapper.Map<List<TaxaMensalRequest>>(taxaMensal);

                return CustomResponse(taxaMensalMapeada != null ? 200 : 404, true, taxaMensalMapeada);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }
    }
}
