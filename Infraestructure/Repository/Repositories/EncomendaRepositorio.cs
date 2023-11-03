using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Infraestructure.Repository.Repositories
{
    public class EncomendaRepositorio : RepositoryGenerics<Encomenda>, IEncomendaRepositorio
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;

        public EncomendaRepositorio()
        {
            this.optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Encomenda>> ListarQuery(Expression<Func<Encomenda, bool>> exEncomenda)
        {
            using (var banco = new ContextBase(optionsBuilder))
            {
                return await banco.Encomenda.Where(exEncomenda).AsNoTracking().ToListAsync();
            }
        }
    }
}
