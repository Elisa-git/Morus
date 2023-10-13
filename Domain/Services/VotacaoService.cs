using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<Votacao>> ListarVotacaos()
        {
            return await votacaoRepositorio.List();
        }

        public async Task<List<Votacao>> ListarPorCondominio(int idCondominio)
        {
            return await votacaoRepositorio.ListarVotacoes(v => v.IdCondominio == idCondominio);
        }

        public async Task CadastrarVotacao(Votacao votacao)
        {
            votacao.Ativa = true;
            votacao.DataCriacao = DateTime.Now;

            if (!_votacaoValidator.ValidarEntidade(votacao))
                throw new ValidacaoException();

            await votacaoRepositorio.Add(votacao);
        }
    }
}
