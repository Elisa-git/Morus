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
        private readonly INotificador notificador;

        public ArquivoController(IArquivoService arquivoService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _arquivoService = arquivoService;
            this.mapper = mapper;
            this.notificador = notificador;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarArquivo")]
        public async Task<IActionResult> SalvarArquivo([FromForm] ArquivoRequest arquivoRequest)
        {
            try
            {
                var pdf = arquivoRequest.Documento;
                var tamanhoArquivo = pdf.Length;

                if (pdf == null || tamanhoArquivo.Equals(0))
                {
                    notificador.Notificar("Arquivo não selecionado");
                    throw new ValidacaoException();
                }

                var documentoMapeado = await _arquivoService.UploadArquivo(arquivoRequest.Documento);
                arquivoRequest.Documento = null;

                var arquivoMap = mapper.Map<Arquivo>(arquivoRequest);
                arquivoMap.Documento = documentoMapeado;
                arquivoMap.TamanhoArquivo = tamanhoArquivo;

                await _arquivoService.SalvarArquivo(arquivoMap);

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

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/DownloadArquivo/{id:int}")]
        public async Task<IActionResult> DownloadArquivo(int id)
        {
            try
            {
                await _arquivoService.DownloadArquivo(id);
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
    }
}
