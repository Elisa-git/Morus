using AutoMapper;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondominioController : ControllerBase
    {
        private readonly CondominioService condominioService;
        private readonly IMapper mapper;

        public CondominioController(CondominioService condominioService, IMapper mapper) 
        { 
            this.condominioService = condominioService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/SalvarCondominio")]
        public async Task<List<Notifies>> SalvarCondominio([FromBody] CondominioRequest condominio)
        {
            //var condominioMapeado = mapper.Map<Condominio>(condominio);
            //return Ok(condominioService.SalvarCondominio(condominioMapeado));

            condominio.UserId = await RetornarIdUsuarioLogado();
            var condominioMapeado = mapper.Map<Condominio>(condominio);

            await condominioService.SalvarCondominio(condominioMapeado);
            return condominioMapeado.ListaNotificacoes;
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;

        }
    }
}
