using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IVotacaoService
    {
        Task AtualizarVotacao(Votacao votacao);
        Task CadastrarVotacao(Votacao votacao);
        Task DeletarVotacao(Votacao votacao);
        Task<List<Votacao>> ListarVotacoes();
    }
}
