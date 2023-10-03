using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TaxaMensalController : ControllerBase
    {
        private readonly ITaxaMensalRepositorio taxaMensalRepositorio;
        private readonly ITaxaMensalService taxaMensalService;
        private readonly IMapper mapper;

        public TaxaMensalController(ITaxaMensalRepositorio taxaMensalRepositorio, ITaxaMensalService taxaMensalService, IMapper mapper)
        {
            this.taxaMensalRepositorio = taxaMensalRepositorio;
            this.taxaMensalService = taxaMensalService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("/api/CadastrarTaxaMensal")]
        public IActionResult CadastrarTaxaMensal(TaxaMensalRequest taxaMensalRequest)
        {
            if (taxaMensalRequest.Id_condominio == null)
                return BadRequest();

            var taxaMensal = mapper.Map<TaxaMensal>(taxaMensalRequest);
            taxaMensalService.CadastrarTaxaMensal(taxaMensal);
            return Ok(taxaMensal);
        }

        [AllowAnonymous]
        [HttpPut("/api/AtualizarTaxaMensal")]
        public TaxaMensal AtualizarTaxaMensal(TaxaMensalRequest taxaMensalRequest)
        {
            var taxaMensal = mapper.Map<TaxaMensal>(taxaMensalRequest);
            taxaMensalRepositorio.Update(taxaMensal);

            return taxaMensal;
        }

        [AllowAnonymous]
        [HttpDelete("/api/ExcluirTaxaMensal")]
        public List<Notifies> ExcluirTaxaMensal(TaxaMensalRequest taxaMensalRequest)
        {
            var taxaMensal = mapper.Map<TaxaMensal>(taxaMensalRequest);
            taxaMensalRepositorio.Delete(taxaMensal);

            return taxaMensal.ListaNotificacoes;
        }

        [AllowAnonymous]
        [HttpGet("/api/ListarTaxaMensal")]
        public async Task<List<TaxaMensalRequest>> ListarTaxaMensal()
        {
            var taxaMensal = await taxaMensalRepositorio.List();
            var taxaMensalMapeada = mapper.Map<List<TaxaMensalRequest>>(taxaMensal);

            return taxaMensalMapeada;
        }
    }
}
