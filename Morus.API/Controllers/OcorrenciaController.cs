using Application.Interfaces;
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
    public class OcorrenciaController : MorusController
    {
        private readonly IOcorrencia _ocorrenciaRepositorio;
        private readonly IOcorrenciaApplication _ocorrenciaApplication;
        private readonly IOcorrenciaService _ocorrenciaService;
        private readonly IMapper mapper;
        private readonly IOcorrencia _IOcorrencia;
        public OcorrenciaController(OcorrenciaRepositorio ocorrenciaRepositorio,
                                    IMapper mapper,
                                    IOcorrencia IOcorrencia,
                                    IOcorrenciaApplication ocorrenciaApplication,
                                    INotificador notificador,
                                    IOcorrenciaService ocorrenciaService) : base(notificador)
        {
            this.mapper = mapper;
            _IOcorrencia = IOcorrencia;
            _ocorrenciaRepositorio = ocorrenciaRepositorio;
            _ocorrenciaApplication = ocorrenciaApplication;
            _ocorrenciaService = ocorrenciaService;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarOcorrencia")]
        public async Task<IActionResult> CadastrarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            try
            {
                var ocorrenciaMapeado = mapper.Map<Ocorrencia>(ocorrenciaRequest);
                await _ocorrenciaService.SalvarOcorrencia(ocorrenciaMapeado);

                return CustomResponse(200, true);
            }
            catch (ValidacaoException e)
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
        [HttpPut("/api/AtualizarOcorrencia")]
        public async Task<IActionResult> AtualizarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<Ocorrencia>(ocorrenciaRequest);
                await _ocorrenciaService.AtualizarOcorrencia(ocorrenciaMap);

                return CustomResponse(200, true);
            }
            catch (ValidacaoException e)
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
        [HttpDelete("/api/DeletarOcorrencia")]
        public async Task<IActionResult> DeletarOcorrencia(OcorrenciaRequest ocorrenciaRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<Ocorrencia>(ocorrenciaRequest);
                await _ocorrenciaService.DeletarOcorrencia(ocorrenciaMap);

                return CustomResponse(200, true);
            }
            catch (ValidacaoException e)
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
        [HttpGet("/api/ListarOcorrencias")]
        public async Task<IActionResult> ListarOcorrencias()
        {
            try
            {
                var ocorrencias = _ocorrenciaService.ListarOcorrencias();
                var ocorrenciaMap = mapper.Map<List<Ocorrencia>>(ocorrencias);

                return CustomResponse(ocorrenciaMap != null ? 200 : 404, true, ocorrenciaMap);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }
    }
}
