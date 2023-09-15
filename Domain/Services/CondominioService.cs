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
