using Application.Interfaces;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces;
using Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Repository.Repositories;
using Domain.Services;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Application
{
    public class EncomendaApplication : IEncomendaApplication
    {
        private readonly IEncomendaRepositorio _encomendaRepositorio;
        private readonly ValidatorBase<Encomenda> _encomendaValidator;
        private readonly IEncomendaService _encomendaService;
        private readonly IUserLogadoApplication _userLogadoApplication;
        private readonly INotificador _notificador;

        public EncomendaApplication(IEncomendaRepositorio encomendaRepositorio, INotificador notificador, IEncomendaService encomendaService, IUserLogadoApplication userLogadoApplication)
        {
            _encomendaRepositorio = encomendaRepositorio;
            _encomendaValidator = new ValidatorBase<Encomenda>(notificador);
            _encomendaService = encomendaService;
            _userLogadoApplication = userLogadoApplication;
            _notificador = notificador;
        }
        public async Task CadastrarEncomenda(Encomenda encomenda)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            encomenda.IdCondominio = usuarioLogado.IdCondominio;

            await _encomendaService.CadastrarEncomenda(encomenda);
        }

        public async Task AtualizarEncomenda(Encomenda encomenda)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            encomenda.IdCondominio = usuarioLogado.IdCondominio;

            await _encomendaService.AtualizarEncomenda(encomenda);
        }

        public async Task<List<Encomenda>> ListarEncomendas()
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            return await _encomendaService.ListarPorCondominio(userLogado.IdCondominio);
        }

        public async Task DeletarEncomenda(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var encomenda = await _encomendaRepositorio.GetEntityById(id);

            if (encomenda == null)
            {
                _notificador.Notificar("Encomenda inexistente.");
                throw new ValidacaoException("");
            }
            if (userLogado.IdCondominio != encomenda.IdCondominio)
            {
                _notificador.Notificar("Usuário não tem permissão para deletar Livro Caixa solicitado.");
                throw new InvalidOperationException();
            }

            await _encomendaService.DeletarEncomenda(encomenda);
        }

        public async Task<Encomenda> ObterPorId(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var encomenda = await _encomendaRepositorio.GetEntityById(id);

            if (encomenda.IdCondominio != userLogado.IdCondominio)
            {
                _notificador.Notificar("Usuário não tem permissão para obter Livro Caixa solicitado.");
                throw new InvalidOperationException();
            }

            return encomenda;
        }
    }
}
