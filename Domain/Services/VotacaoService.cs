using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class VotacaoService : IVotacaoService
    {
        private readonly IVotacaoRepositorio votacaoRepositorio;
        private readonly ValidatorBase<Votacao> _votacaoValidator;

        public VotacaoService(IVotacaoRepositorio votacaoRepositorio, INotificador notificador)
        {
            this.votacaoRepositorio = votacaoRepositorio;
            _votacaoValidator = new ValidatorBase<Votacao>(notificador);
        }

        public async Task CadastrarVotacao(Votacao votacao)
        {
            if (_votacaoValidator.ValidarEntidade(votacao))
                throw new ValidacaoException();

            await votacaoRepositorio.Add(votacao);
        }

        public async Task AtualizarVotacao(Votacao votacao)
        {
            if (_votacaoValidator.ValidarEntidade(votacao))
                throw new ValidacaoException();

            await votacaoRepositorio.Update(votacao);
        }

        public async Task DeletarVotacao(Votacao votacao)
        {
            await votacaoRepositorio.Delete(votacao);
        }

        public async Task<List<Votacao>> ListarVotacoes()
        {
            return await votacaoRepositorio.List();
        }
    }
}
