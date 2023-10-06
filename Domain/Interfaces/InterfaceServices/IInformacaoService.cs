using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IInformacaoService
    {
        Task CadastrarInformacao(Informacao informacaoRequest);

        Task AtualizarInformacao(Informacao informacaoRequest);

        Task<List<Informacao>> ListarInformacoesAtivas();
        Task DeletarInformacao(Informacao informacaoRequest);
    }
}
