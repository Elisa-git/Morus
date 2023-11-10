using Application.Interfaces;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TaxaMensalApplication : ITaxaMensalApplication
    {
        private readonly INotificador _notificador;
        private readonly ITaxaMensalService _taxaMensalService;
        private readonly IUserLogadoApplication _userLogadoApplication;
        private readonly ITaxaMensalRepositorio _repositorio;

        public TaxaMensalApplication(IUserLogadoApplication userLogadoApplication, ITaxaMensalService taxaMensalService, INotificador notificador, ITaxaMensalRepositorio repositorio)
        {
            _notificador = notificador;
            _taxaMensalService = taxaMensalService;
            _userLogadoApplication = userLogadoApplication;
            _repositorio = repositorio;
        }

        public async Task CadastrarTaxaMensal(TaxaMensal taxaMensal)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            taxaMensal.IdCondominio = usuarioLogado.IdCondominio;

            await _taxaMensalService.CadastrarTaxaMensal(taxaMensal);
        }

        public async Task AtualizarTaxaMensal(TaxaMensal taxaMensal)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            taxaMensal.IdCondominio = usuarioLogado.IdCondominio;

            await _taxaMensalService.AtualizarTaxaMensal(taxaMensal);
        }

        public async Task Deletar(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var taxaMensal = await ObterPorId(id);

            await _repositorio.Delete(taxaMensal);
        }

        public async Task<TaxaMensal> ObterPorId(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var taxaMensal = await _repositorio.GetEntityById(id);

            if (taxaMensal == null)
            {
                _notificador.Notificar("Taxa Mensal inexistente.");
                throw new ValidacaoException("");
            }
            if (taxaMensal.IdCondominio != userLogado.IdCondominio)
            {
                _notificador.Notificar("Usuário não tem permissão para acessar taxa mensal solicitada.");
                throw new InvalidOperationException();
            }

            return taxaMensal;
        }
    }
}
