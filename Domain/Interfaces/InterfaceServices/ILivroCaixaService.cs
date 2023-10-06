using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface ILivroCaixaService
    {
        Task CadastrarLivroCaixa(LivroCaixa livroCaixa);
    }
}
