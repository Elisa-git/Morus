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
    public class ArquivoController : MorusController
    {
        private readonly IArquivoService _arquivoService;
        private readonly IMapper mapper;

        public ArquivoController(IArquivoService arquivoService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _arquivoService = arquivoService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarArquivo")]
        public async Task<IActionResult> CadastrarArquivo(ArquivoRequest arquivoRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<Arquivo>(arquivoRequest);
                await _arquivoService.CadastrarArquivo(ocorrenciaMap); 
                
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
        [HttpPut("/api/EditarArquivo")]
        public async Task<IActionResult> AtualizarArquivo(ArquivoRequest arquivoRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<Arquivo>(arquivoRequest);
                await _arquivoService.AtualizarArquivo(ocorrenciaMap);

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
        [HttpDelete("/api/DeletarArquivo")]
        public async Task<IActionResult> DeletarArquivo(ArquivoRequest arquivoRequest)
        {
            try
            {
                var ocorrenciaMap = mapper.Map<Arquivo>(arquivoRequest);
                await _arquivoService.DeletarArquivo(ocorrenciaMap);

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
        [HttpGet("/api/ListarArquivos")]
        public async Task<IActionResult> ListarArquivos()
        {
            try
            {
                var arquivos = await _arquivoService.ListarArquivos();
                var arquivosMap = mapper.Map<List<ArquivoRequest>>(arquivos);

                return CustomResponse(arquivosMap != null ? 200 : 404, true, arquivosMap);
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
