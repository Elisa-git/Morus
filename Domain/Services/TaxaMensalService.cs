using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;

namespace Domain.Services
{
    public class TaxaMensalService : ITaxaMensalService
    {
        private readonly ITaxaMensalRepositorio taxaMensalRepositorio;

        public TaxaMensalService(ITaxaMensalRepositorio taxaMensalRepositorio)
        {
            this.taxaMensalRepositorio = taxaMensalRepositorio;
        }

        public async Task CadastrarTaxaMensal(TaxaMensal taxaMensal)
        {
            await taxaMensalRepositorio.Add(taxaMensal);
        }
    }
}
