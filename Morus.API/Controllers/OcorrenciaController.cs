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
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrencia _ocorrenciaRepositorio;
        private readonly IMapper mapper;
        private readonly IOcorrencia _IOcorrencia;
        public OcorrenciaController(OcorrenciaRepositorio ocorrenciaRepositorio, IMapper mapper, IMulta IOcorrencia)
        {
            this.mapper = mapper;
            _IOcorrencia = IOcorrencia;
            _ocorrenciaRepositorio = ocorrenciaRepositorio;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarOcorrencia")]
        public async Task<List<Notifies>> CadastrarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            var ocorrenciaMapeado= mapper.Map<Ocorrencia>(ocorrenciaRequest);
            await _ocorrenciaRepositorio.Add(ocorrenciaMapeado);
            return ocorrenciaMapeado.ListaNotificacoes;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarOcorrencia")]
        public async Task<List<Notifies>> AtualizarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            var ocorrenciaMap = mapper.Map<Ocorrencia>(ocorrenciaRequest);
            await _ocorrenciaRepositorio.Update(ocorrenciaMap);
            return ocorrenciaMap.ListaNotificacoes;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarOcorrencia")]
        public async Task<List<Notifies>> DeletarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            var ocorrenciaMap = mapper.Map<Ocorrencia>(ocorrenciaRequest);
            await _ocorrenciaRepositorio.Delete(ocorrenciaMap);
            return ocorrenciaMap.ListaNotificacoes;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarOcorrencias")]
        public async Task<List<Ocorrencia>> ListarOcorrencias()
        {
            var ocorrencias = await _IOcorrencia.List();
            var ocorrenciaMap = mapper.Map<List<Ocorrencia>>(ocorrencias);
            return ocorrenciaMap;
        }
    }
}
