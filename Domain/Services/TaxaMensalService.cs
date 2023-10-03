using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
