using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository.Repositories
{
    public class VotacaoRepositorio : RepositoryGenerics<Votacao>, IVotacaoRepositorio
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;

        public VotacaoRepositorio()
        {
            this.optionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
