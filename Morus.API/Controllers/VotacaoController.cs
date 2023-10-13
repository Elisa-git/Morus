using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
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

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ListarVotacoes")]
        public async Task<IActionResult> ListarVotacoes()
        {
            try
            {
                return CustomResponse(200, true, (await _votacaoApplication.ListarVotacoesCondominio()));
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
    }
}
