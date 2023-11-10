using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class TaxaMensalService : ITaxaMensalService
    {
        private readonly ITaxaMensalRepositorio taxaMensalRepositorio;
        private readonly ValidatorBase<TaxaMensal> taxaMensalValidator;
        private readonly INotificador notificador;

        public TaxaMensalService(ITaxaMensalRepositorio taxaMensalRepositorio, INotificador notificador)
        {
            this.taxaMensalRepositorio = taxaMensalRepositorio;
            this.taxaMensalValidator = new ValidatorBase<TaxaMensal>(notificador);
            this.notificador = notificador;
        }

        public async Task CadastrarTaxaMensal(TaxaMensal taxaMensal)
        {
            if (!taxaMensalValidator.ValidarEntidade(taxaMensal))
                throw new ValidacaoException();

            await taxaMensalRepositorio.Add(taxaMensal);
        }

        public async Task<List<TaxaMensal>> ListarTaxaMensal()
        {
            return await taxaMensalRepositorio.List();
        }

        public async Task AtualizarTaxaMensal(TaxaMensal taxaMensal)
        {
            if (!taxaMensalValidator.ValidarEntidade(taxaMensal))
                throw new ValidacaoException();

            await taxaMensalRepositorio.Update(taxaMensal);
        }
    }
}
