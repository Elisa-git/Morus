using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepositorio arquivoRepositorio;
        private readonly ValidatorBase<Arquivo> _arquivoValidator;

        public ArquivoService(IArquivoRepositorio arquivoRepositorio, INotificador notificador)
        {
            this.arquivoRepositorio = arquivoRepositorio;
            _arquivoValidator = new ValidatorBase<Arquivo>(notificador);
        }

        public async Task CadastrarArquivo(Arquivo arquivo)
        {
            if (_arquivoValidator.ValidarEntidade(arquivo))
                throw new ValidacaoException();

            await arquivoRepositorio.Add(arquivo);
        }

        public async Task AtualizarArquivo(Arquivo arquivo)
        {
            if (_arquivoValidator.ValidarEntidade(arquivo))
                throw new ValidacaoException();

            await arquivoRepositorio.Update(arquivo);
        }

        public async Task DeletarArquivo(Arquivo arquivo)
        {
            await arquivoRepositorio.Delete(arquivo);
        }

        public async Task<List<Arquivo>> ListarArquivos()
        {
            return await arquivoRepositorio.List();
        }
    }
}
