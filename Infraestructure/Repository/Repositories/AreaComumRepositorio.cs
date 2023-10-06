using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repository.Repositories
{
    public class AreaComumRepositorio : RepositoryGenerics<AreaComum>, IAreaComumRepositorio
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public AreaComumRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<AreaComum>> ListarAreasComuns(Expression<Func<AreaComum, bool>> exAreaComum)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.AreaComum.Where(exAreaComum).AsNoTracking().ToListAsync();
            }
        }
    }
}
