using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class CondominioService : ICondominioService
    {
        private readonly ICondominio condominioGenerico;
        private readonly ValidatorBase<Condominio> condominioValidator;

        public CondominioService(ICondominio condominioGenerico, INotificador notificador)
        {
            this.condominioGenerico = condominioGenerico;
            this.condominioValidator = new ValidatorBase<Condominio>(notificador);
        }

        public async Task SalvarCondominio(Condominio condominio)
        {
            await condominioGenerico.Add(condominio);
        }

        public async Task AtualizarCondominio(Condominio condominio)
        {
            if (!condominioValidator.ValidarEntidade(condominio))
                throw new ValidacaoException();

            await condominioGenerico.Update(condominio);
        }
    }
}
