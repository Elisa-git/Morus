using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface ICondominioService
    {
        Task SalvarCondominio(Condominio condominio);
    }
}
