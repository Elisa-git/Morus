using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
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
    public class OcorrenciaController : MorusController
    {
        private readonly IOcorrencia _ocorrenciaRepositorio;
        private readonly IOcorrenciaApplication _ocorrenciaApplication;
        private readonly IMapper mapper;
        private readonly IOcorrencia _IOcorrencia;
        public OcorrenciaController(OcorrenciaRepositorio ocorrenciaRepositorio, IMapper mapper, IOcorrencia IOcorrencia, IOcorrenciaApplication ocorrenciaApplication, INotificador notificador) : base(notificador)
        {
            this.mapper = mapper;
            _IOcorrencia = IOcorrencia;
            _ocorrenciaRepositorio = ocorrenciaRepositorio;
            _ocorrenciaApplication = ocorrenciaApplication;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarOcorrencia")]
        public async Task<IActionResult> CadastrarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            try
            {
                var ocorrenciaMapeado= mapper.Map<Ocorrencia>(ocorrenciaRequest);
                await _ocorrenciaApplication.CadastrarOcorrencia(ocorrenciaMapeado);

                return CustomResponse(200, true);
            }
            catch(ValidacaoException e)
            {
                return CustomResponse(400, false);
            }
            catch(Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarOcorrencia")]
        public async Task<IActionResult> AtualizarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            var ocorrenciaMap = mapper.Map<Ocorrencia>(ocorrenciaRequest);
            await _ocorrenciaRepositorio.Update(ocorrenciaMap);
            //return ocorrenciaMap.ListaNotificacoes;
            return Ok();
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarOcorrencia")]
        public async Task<IActionResult> DeletarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            var ocorrenciaMap = mapper.Map<Ocorrencia>(ocorrenciaRequest);
            await _ocorrenciaRepositorio.Delete(ocorrenciaMap);
            //return ocorrenciaMap.ListaNotificacoes;
            return Ok();
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarOcorrencias")]
        public async Task<IActionResult> ListarOcorrencias()
        {
            var ocorrencias = await _IOcorrencia.List();
            var ocorrenciaMap = mapper.Map<List<Ocorrencia>>(ocorrencias);
            return Ok(ocorrenciaMap);
        }
    }
}
