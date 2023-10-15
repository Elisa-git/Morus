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

namespace Application
{
    public class LivroCaixaApplication : ILivroCaixaApplication
    {
        private readonly ILivroCaixaRepositorio _livroCaixaRepositorio;
        private readonly ValidatorBase<LivroCaixa> _livroCaixaValidator;
        private readonly ILivroCaixaService _livroCaixaService;
        private readonly IUserLogadoApplication _userLogadoApplication;
        private readonly INotificador _notificador;

        public LivroCaixaApplication(ILivroCaixaRepositorio livroCaixaRepositorio, INotificador notificador, ILivroCaixaService livroCaixaService, IUserLogadoApplication userLogadoApplication)
        {
            _livroCaixaRepositorio = livroCaixaRepositorio;
            _livroCaixaValidator = new ValidatorBase<LivroCaixa>(notificador);
            _livroCaixaService = livroCaixaService;
            _userLogadoApplication = userLogadoApplication;
            _notificador = notificador;
        }
        public async Task CadastrarLivroCaixa(LivroCaixa livroCaixa)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            livroCaixa.IdCondominio = usuarioLogado.IdCondominio;

            await _livroCaixaService.CadastrarLivroCaixa(livroCaixa);
        }

        public async Task AtualizarLivroCaixa(LivroCaixa livroCaixa)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            livroCaixa.IdCondominio = usuarioLogado.IdCondominio;

            await _livroCaixaService.AtualizarLivroCaixa(livroCaixa);
        }

        public async Task<List<LivroCaixa>> ListarLivroCaixas()
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            return await _livroCaixaService.ListarPorCondominio(userLogado.IdCondominio);
        }

        public async Task DeletarLivroCaixa(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var livroCaixa = await _livroCaixaRepositorio.GetEntityById(id);

            if (livroCaixa == null)
            {
                _notificador.Notificar("Livro Caixa inexistente.");
                throw new ValidacaoException("");
            }
            if (userLogado.IdCondominio != livroCaixa.IdCondominio)
            {
                _notificador.Notificar("Usuário não tem permissão para deletar Livro Caixa solicitado.");
                throw new InvalidOperationException();
            }

            await _livroCaixaService.DeletarLivroCaixa(livroCaixa);
        }
    }
}
