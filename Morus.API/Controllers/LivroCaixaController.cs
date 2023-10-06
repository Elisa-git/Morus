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
    public class LivroCaixaController : MorusController
    {
        private readonly ILivroCaixaService _livroCaixaService;
        private readonly IMapper mapper;

        public LivroCaixaController(ILivroCaixaService livroCaixaService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _livroCaixaService = livroCaixaService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarLivroCaixa")]
        public async Task<IActionResult> CadastrarLivroCaixa(LivroCaixaRequest livroCaixaRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<LivroCaixa>(livroCaixaRequest);
                await _livroCaixaService.CadastrarLivroCaixa(ocorrenciaMap); 
                
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
        [HttpPut("/api/EditarLivroCaixa")]
        public async Task<IActionResult> AtualizarLivroCaixa(LivroCaixaRequest livroCaixaRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<LivroCaixa>(livroCaixaRequest);
                await _livroCaixaService.AtualizarLivroCaixa(ocorrenciaMap);

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
        [HttpDelete("/api/DeletarLivroCaixa")]
        public async Task<IActionResult> DeletarLivroCaixa(LivroCaixaRequest livroCaixaRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<LivroCaixa>(livroCaixaRequest);
                await _livroCaixaService.DeletarLivroCaixa(ocorrenciaMap);

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
        [HttpGet("/api/ListarLivroCaixa")]
        public async Task<IActionResult> ListarLivroCaixa()
        {
            try
            {
                var livrosCaixa = await _livroCaixaService.ListarLivrosCaixa();
                var livrosCaixaMap = mapper.Map<List<LivroCaixaRequest>>(livrosCaixa);

                return CustomResponse(livrosCaixaMap != null ? 200 : 404, true, livrosCaixaMap);
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
