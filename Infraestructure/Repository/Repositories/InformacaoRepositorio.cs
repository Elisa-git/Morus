using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
