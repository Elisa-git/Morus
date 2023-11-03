using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class EncomendaService : IEncomendaService
    {
        private readonly IEncomendaRepositorio encomendaRepositorio;
        private readonly ValidatorBase<Encomenda> _encomendaValidator;

        public EncomendaService(IEncomendaRepositorio encomendaRepositorio, INotificador notificador)
        {
            this.encomendaRepositorio = encomendaRepositorio;
            _encomendaValidator = new ValidatorBase<Encomenda>(notificador);
        }

        public async Task CadastrarEncomenda(Encomenda encomenda)
        {
            if (!_encomendaValidator.ValidarEntidade(encomenda))
                throw new ValidacaoException();

            await encomendaRepositorio.Add(encomenda);
        }

        public async Task AtualizarEncomenda(Encomenda encomenda)
        {
            if (!_encomendaValidator.ValidarEntidade(encomenda))
                throw new ValidacaoException();

            await encomendaRepositorio.Update(encomenda);
        }

        public async Task DeletarEncomenda(Encomenda encomenda)
        {
            await encomendaRepositorio.Delete(encomenda);
        }

        public async Task<List<Encomenda>> ListarEncomendas()
        {
            return await encomendaRepositorio.List();
        }

        public async Task<List<Encomenda>> ListarPorCondominio(int idCondominio)
        {
            return await encomendaRepositorio.ListarQuery(l => l.IdCondominio == idCondominio);
        }
    }
}
