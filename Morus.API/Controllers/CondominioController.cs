using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Entities.Entities.Enum;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : ControllerBase
    {
        private readonly CondominioRepositorio _condominioRepositorio;
        private readonly IMapper mapper;

        public CondominioController(CondominioRepositorio condominioRepositorio, IMapper mapper) 
        { 
            _condominioRepositorio = condominioRepositorio;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarCondominio")]
        public async Task<List<Notifies>> CadastrarCondominio(CondominioRequest condominioRequest)
        {
            //var condominioMapeado = mapper.Map<Condominio>(condominio);
            //return Ok(condominioService.SalvarCondominio(condominioMapeado));

            condominioRequest.UserId = await RetornarIdUsuarioLogado();
            var condominioMapeado = mapper.Map<Condominio>(condominioRequest);
            await _condominioRepositorio.Add(condominioMapeado);
            return condominioMapeado.ListaNotificacoes;

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarCondominio")]
        public async Task<List<Notifies>> AtualizarCondominio(CondominioRequest condominioRequest)
        {
            var condominioMapeado = mapper.Map<Condominio>(condominioRequest);
            await _condominioRepositorio.Update(condominioMapeado);
            return condominioMapeado.ListaNotificacoes;
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            return "54181da4-4e19-45df-bfa4-8f339c3bb46b";
        }
    }
}


