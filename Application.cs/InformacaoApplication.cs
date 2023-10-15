using Application.Interfaces;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Domain.Validacoes;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Application
{
    public class InformacaoApplication : IInformacaoApplication
    {
        private readonly IInformacaoRepositorio _informacaoRepositorio;
        private readonly ValidatorBase<Informacao> _informacaoValidator;
        private readonly IInformacaoService _informacaoService;
        private readonly IUserLogadoApplication _userLogadoApplication;
        private readonly INotificador _notificador;

        public InformacaoApplication(IInformacaoRepositorio informacaoRepositorio, INotificador notificador, IInformacaoService informacaoService, IUserLogadoApplication userLogadoApplication)
        {
            _informacaoRepositorio = informacaoRepositorio;
            _informacaoValidator = new ValidatorBase<Informacao>(notificador);
            _informacaoService = informacaoService;
            _userLogadoApplication = userLogadoApplication;
            _notificador = notificador;
        }

        public async Task AtualizarInformacao(Informacao informacaoMapeada)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            informacaoMapeada.IdCondominio = usuarioLogado.IdCondominio;

            await _informacaoService.AtualizarInformacao(informacaoMapeada);
        }

        public async Task CadastrarInformacao(Informacao informacaoMapeada)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            informacaoMapeada.IdCondominio = usuarioLogado.IdCondominio;

            await _informacaoService.CadastrarInformacao(informacaoMapeada);
        }

        public async Task<List<Informacao>> ListarInformacoesCondominio()
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            return await _informacaoService.ListarInformacoesAtivasPorCondominio(usuarioLogado.IdCondominio);
        }

        public async Task DeletarInformacao(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var informacao = await _informacaoRepositorio.GetEntityById(id);

            if (informacao == null)
            {
                _notificador.Notificar("Informação inexistente.");
                throw new ValidacaoException("");
            }
            if (userLogado.IdCondominio != informacao.IdCondominio)
            {
                _notificador.Notificar("Usuário não tem permissão para deletar informação solicitada.");
                throw new InvalidOperationException();
            }

            await _informacaoService.DeletarInformacao(informacao);
        }
    }
}
