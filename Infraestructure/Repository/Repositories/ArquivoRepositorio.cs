using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository.Repositories
{
    public class ArquivoRepositorio : RepositoryGenerics<Arquivo>, IArquivoRepositorio
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;

        public ArquivoRepositorio()
        {
            this.optionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
