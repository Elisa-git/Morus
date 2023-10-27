using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface ITaxaMensalService
    {
        Task CadastrarTaxaMensal(TaxaMensal taxaMensal);
        Task<List<TaxaMensal>> ListarTaxaMensal();
        Task AtualizarTaxaMensal(TaxaMensal taxaMensal);
    }
}
