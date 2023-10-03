using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
