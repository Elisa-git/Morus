using Application.Interfaces;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces.InterfaceServices;
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

        public TaxaMensalApplication(IUserLogadoApplication userLogadoApplication, ITaxaMensalService taxaMensalService, INotificador notificador)
        {
            _notificador = notificador;
            _taxaMensalService = taxaMensalService;
            _userLogadoApplication = userLogadoApplication;
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
    }
}
