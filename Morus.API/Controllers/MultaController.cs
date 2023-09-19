using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultaController : ControllerBase
    {
        private readonly MultaRepositorio _multaRepositorio;
        private readonly IMapper mapper;
        private readonly IMulta _IMulta;
        public MultaController(MultaRepositorio multaRepositorio, IMapper mapper, IMulta IMulta)
        {
            this.mapper = mapper;
            _IMulta = IMulta;
            _multaRepositorio = multaRepositorio;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarMulta")]
        public async Task<List<Notifies>> CadastrarMulta(MultaRequest multaRequest)
        {
            var multaMapeado= mapper.Map<Multa>(multaRequest);
            await _multaRepositorio.Add(multaMapeado);
            return multaMapeado.ListaNotificacoes;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarMulta")]
        public async Task<List<Notifies>> AtualizarMulta(MultaRequest multaRequest)
        {
            var multaMap = mapper.Map<Multa>(multaRequest);
            await _multaRepositorio.Update(multaMap);
            return multaMap.ListaNotificacoes;
        }

        //[AllowAnonymous]
        //[Produces("application/json")]
        //[HttpDelete("/api/DeletarMulta")]
        //public async Task<List<Notifies>> DeletarMulta(MultaRequest multaRequest)
        //{
        //    var multaMap = mapper.Map<Multa>(multaRequest);
        //    await _multaRepositorio.Delete(multaMap);
        //    return multaMap.ListaNotificacoes;
        //}

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
        public async Task<List<Multa>> ListarMultas()
        {
            var multas = await _IMulta.List();
            var multaMap = mapper.Map<List<Multa>>(multas);
            return multaMap;
        }
    }
}
