using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotacaoController : MorusController
    {
        private readonly IVotacaoService _votacaoService;
        private readonly IMapper mapper;

        public VotacaoController(IVotacaoService votacaoService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _votacaoService = votacaoService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarVotacao")]
        public async Task<IActionResult> CadastrarVotacao(VotacaoRequest votacaoRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<Votacao>(votacaoRequest);
                await _votacaoService.CadastrarVotacao(ocorrenciaMap); 
                
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
        [HttpPut("/api/EditarVotacao")]
        public async Task<IActionResult> AtualizarVotacao(VotacaoRequest votacaoRequest)
        {
            try
            {
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

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarVotacao")]
        public async Task<IActionResult> ListarVotacao()
        {
            try
            {
                var votacoes = await _votacaoService.ListarVotacoes();
                var votacoesMap = mapper.Map<List<VotacaoRequest>>(votacoes);

                return CustomResponse(votacoesMap != null ? 200 : 404, true, votacoesMap);
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
