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
    public class InformacaoRepositorio : RepositoryGenerics<Informacao>, IInformacaoRepositorio
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public InformacaoRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Informacao>> ListarInformacoes(Expression<Func<Informacao, bool>> exInformacao)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Informacao.Where(exInformacao).AsNoTracking().ToListAsync();
            }
        }
    }
}
