using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;

namespace Domain.Services
{
    public class MultaService : IMultaService
    {
        private readonly IMulta multaGenerico;

        public MultaService(IMulta multaGenerico)
        {
            this.multaGenerico = multaGenerico;
        }

        public async Task SalvarMulta(Multa multa)
        {
            await multaGenerico.Add(multa);
        }
    }
}
