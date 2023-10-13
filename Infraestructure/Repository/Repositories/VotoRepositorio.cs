using Domain.Entities;
using Domain.Interfaces;
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
    public class VotoRepositorio : RepositoryGenerics<Voto>, IVotoRepositorio
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public VotoRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Voto>> ListarVotos(Expression<Func<Voto, bool>> exInformacao)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Voto.Where(exInformacao).AsNoTracking().ToListAsync();
            }
        }
    }
}
