using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

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
