using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface ILivroCaixaService
    {
        Task AtualizarLivroCaixa(LivroCaixa livroCaixa);
        Task CadastrarLivroCaixa(LivroCaixa livroCaixa);
        Task DeletarLivroCaixa(LivroCaixa livroCaixa);
        Task<List<LivroCaixa>> ListarLivrosCaixa();
    }
}
