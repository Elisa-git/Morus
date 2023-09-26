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
    public class OcorrenciaRepositorio : RepositoryGenerics<Ocorrencia>, IOcorrencia
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public OcorrenciaRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Ocorrencia>> ListarMessage(Expression<Func<Ocorrencia, bool>> exMessage)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Ocorrencia.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
