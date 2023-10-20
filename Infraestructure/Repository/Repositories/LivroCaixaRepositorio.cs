using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Infraestructure.Repository.Repositories
{
    public class LivroCaixaRepositorio : RepositoryGenerics<LivroCaixa>, ILivroCaixaRepositorio
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;

        public LivroCaixaRepositorio()
        {
            this.optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<LivroCaixa>> ListarQuery(Expression<Func<LivroCaixa, bool>> exLivroCaixa)
        {
            using (var banco = new ContextBase(optionsBuilder))
            {
                return await banco.LivroCaixa.Where(exLivroCaixa).AsNoTracking().ToListAsync();
            }
        }
    }
}
