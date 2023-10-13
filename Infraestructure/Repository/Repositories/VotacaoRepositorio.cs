using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class VotacaoRepositorio : RepositoryGenerics<Votacao>, IVotacaoRepositorio
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public VotacaoRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Votacao>> ListarVotacoes(Expression<Func<Votacao, bool>> exInformacao)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
        {
                return await banco.Votacao.Where(exInformacao).AsNoTracking().ToListAsync();
            }
        }
    }
}
