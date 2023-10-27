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
    public class VotacaoController : MorusController
    {
        private readonly IVotacaoRepositorio _votacaoRepositorio;
        private readonly IVotacaoApplication _votacaoApplication;
        private readonly IVotacaoService _votacaoService;
        private readonly IMapper mapper;
        public VotacaoController(IVotacaoRepositorio votacaoRepositorio,
                                IMapper mapper,
                                IVotacaoApplication votacaoApplication,
                                INotificador notificador,
                                IVotacaoService votacaoService) : base(notificador)
        {
            this.mapper = mapper;;
            _votacaoRepositorio = votacaoRepositorio;
            _votacaoApplication = votacaoApplication;
            _votacaoService = votacaoService;
            this.mapper = mapper;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarVotacao")]
        public async Task<IActionResult> CadastrarVotacao(CadastrarVotacaoRequest votacaoRequest)
        {
            try
            {
                var ocorrenciaMapeado = mapper.Map<Votacao>(votacaoRequest);
                await _votacaoApplication.CadastrarVotacao(ocorrenciaMapeado);
                
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

        [Authorize(Roles = "Sindico,Morador")]
        [Produces("application/json")]
        [HttpPost("/api/RegistrarVoto")]
        public async Task<IActionResult> RegistrarVoto(RegistrarVotoRequest registrarVotoRequest)
        {
            try
            {
                var votoMapeado = mapper.Map<Voto>(registrarVotoRequest);
                await _votacaoApplication.RegistrarVoto(votoMapeado);
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

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ObterContagemVotacao/{idVotacao:int}")]
        public async Task<IActionResult> ObterContagemVotacao([FromRoute] int idVotacao)
        {
            try
            {
                var response = await _votacaoApplication.ContadorVotacao(idVotacao);
                return CustomResponse(200, true, response);
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
        [HttpPut("/api/EditarVotacao")]
        public async Task<IActionResult> AtualizarVotacao(VotacaoRequest votacaoRequest)
        {
            try
            {
                if (votacaoRequest.Id == null)
                {
                    _notificador.Notificar("Informe o Id");
                    throw new ValidacaoException();
                }

                var ocorrenciaMap = mapper.Map<Votacao>(votacaoRequest);
                await _votacaoService.AtualizarVotacao(ocorrenciaMap);

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
        [HttpDelete("/api/DeletarVotacao")]
        public async Task<IActionResult> DeletarVotacao(VotacaoRequest votacaoRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<Votacao>(votacaoRequest);
                await _votacaoService.DeletarVotacao(ocorrenciaMap);

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

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListarVotacao")]
        public async Task<IActionResult> ListarVotacao()
        {
            try
            {
                var votacoes = await _votacaoApplication.ListarVotacoesCondominio();

                return CustomResponse(votacoes != null ? 200 : 404, true, votacoes);
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
    }
}
