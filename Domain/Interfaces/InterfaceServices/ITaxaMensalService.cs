using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface ITaxaMensalService
    {
        Task CadastrarTaxaMensal(TaxaMensal taxaMensal);
    }
}
