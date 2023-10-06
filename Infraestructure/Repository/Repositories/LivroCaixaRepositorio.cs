using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository.Repositories
{
    public class LivroCaixaRepositorio : RepositoryGenerics<LivroCaixa>, ILivroCaixaRepositorio
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;

        public LivroCaixaRepositorio()
        {
            this.optionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
