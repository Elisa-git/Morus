using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class LivroCaixaService : ILivroCaixaService
    {
        private readonly ILivroCaixaRepositorio livroCaixaRepositorio;
        private readonly ValidatorBase<LivroCaixa> _livroCaixaValidator;

        public LivroCaixaService(ILivroCaixaRepositorio livroCaixaRepositorio, INotificador notificador)
        {
            this.livroCaixaRepositorio = livroCaixaRepositorio;
            _livroCaixaValidator = new ValidatorBase<LivroCaixa>(notificador);
        }

        public async Task CadastrarLivroCaixa(LivroCaixa livroCaixa)
        {
            if (_livroCaixaValidator.ValidarEntidade(livroCaixa))
                throw new ValidacaoException();

            await livroCaixaRepositorio.Add(livroCaixa);
        }

        public async Task AtualizarLivroCaixa(LivroCaixa livroCaixa)
        {
            if (_livroCaixaValidator.ValidarEntidade(livroCaixa))
                throw new ValidacaoException();

            await livroCaixaRepositorio.Update(livroCaixa);
        }

        public async Task DeletarLivroCaixa(LivroCaixa livroCaixa)
        {
            await livroCaixaRepositorio.Delete(livroCaixa);
        }

        public async Task<List<LivroCaixa>> ListarLivrosCaixa()
        {
            return await livroCaixaRepositorio.List();
        }

        public async Task<List<LivroCaixa>> ListarPorCondominio(int idCondominio)
        {
            return await livroCaixaRepositorio.ListarQuery(l => l.IdCondominio == idCondominio);
        }
    }
}
