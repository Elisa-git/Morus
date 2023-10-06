using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IMultaService
    {
        Task SalvarMulta(Multa multa);
    }
}
