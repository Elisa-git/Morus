using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;

namespace Domain.Services
{
    public class CondominioService : ICondominioService
    {
        private readonly ICondominio condominioGenerico;

        public CondominioService(ICondominio condominioGenerico)
        {
            this.condominioGenerico = condominioGenerico;
        }

        public async Task SalvarCondominio(Condominio condominio)
        {
            await condominioGenerico.Add(condominio);
        }
    }
}
