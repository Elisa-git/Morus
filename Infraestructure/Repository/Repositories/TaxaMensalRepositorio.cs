using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class TaxaMensalRepositorio : RepositoryGenerics<TaxaMensal>, ITaxaMensalRepositorio
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public TaxaMensalRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
