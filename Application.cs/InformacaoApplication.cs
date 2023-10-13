﻿using Application.Interfaces;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Application
{
    public class InformacaoApplication : IInformacaoApplication
    {
        private readonly IInformacaoRepositorio _informacaoRepositorio;
        private readonly ValidatorBase<Informacao> _informacaoValidator;
        private readonly IInformacaoService _informacaoService;
        private readonly IUserLogadoApplication _userLogadoApplication;

        public InformacaoApplication(IInformacaoRepositorio informacaoRepositorio, INotificador notificador, IInformacaoService informacaoService, IUserLogadoApplication userLogadoApplication)
        {
            _informacaoRepositorio = informacaoRepositorio;
            _informacaoValidator = new ValidatorBase<Informacao>(notificador);
            _informacaoService = informacaoService;
            _userLogadoApplication = userLogadoApplication;
        }

        public async Task CadastrarInformacao(Informacao informacaoMapeada)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            informacaoMapeada.Id_condominio = usuarioLogado.Id_condominio;

            await _informacaoService.CadastrarInformacao(informacaoMapeada);
        }

        public async Task<List<Informacao>> ListarInformacoesCondominio()
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            return await _informacaoService.ListarInformacoesAtivasPorCondominio(usuarioLogado.Id_condominio);
        }
    }
}
