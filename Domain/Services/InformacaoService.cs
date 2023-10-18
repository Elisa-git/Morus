using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class InformacaoService : IInformacaoService
    {
        private readonly IInformacaoRepositorio informacaoRepositorio;
        private readonly ValidatorBase<Informacao> _informacaoValidator;

        public InformacaoService(IInformacaoRepositorio informacaoRepositorio, INotificador notificador)
        {
            this.informacaoRepositorio = informacaoRepositorio;
            _informacaoValidator = new ValidatorBase<Informacao>(notificador);
        }

        public async Task CadastrarInformacao(Informacao informacaoRequest)
        {
            if (!_informacaoValidator.ValidarEntidade(informacaoRequest))
                throw new ValidacaoException();
            
            informacaoRequest.DataCadastro = DateTime.Now;
            informacaoRequest.DataAlteracao = DateTime.Now;
            informacaoRequest.Ativo = true;
            await informacaoRepositorio.Add(informacaoRequest);
        }

        public async Task AtualizarInformacao(Informacao informacaoRequest)
        {
            if (!_informacaoValidator.ValidarEntidade(informacaoRequest))
                throw new ValidacaoException();
            
            informacaoRequest.DataAlteracao = DateTime.Now;
            await informacaoRepositorio.Update(informacaoRequest);
        }

        public async Task DeletarInformacao(Informacao informacaoRequest)
        { 
            await informacaoRepositorio.Delete(informacaoRequest);
        }

        public async Task<List<Informacao>> ListarInformacoesAtivas()
        {
            return await informacaoRepositorio.ListarInformacoes(n => n.Ativo);
        }

        public async Task<List<Informacao>> ListarInformacoesAtivasPorCondominio(int idCondominio)
        {
            return await informacaoRepositorio.ListarInformacoes(n => n.Ativo && n.Id_condominio == idCondominio);
        }
    }
}