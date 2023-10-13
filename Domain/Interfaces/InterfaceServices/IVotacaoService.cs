using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IVotacaoService
    {
        Task CadastrarVotacao(Votacao votacao);
        Task<List<Votacao>> ListarPorCondominio(int idCondominio);
    }
}