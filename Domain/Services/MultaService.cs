using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
