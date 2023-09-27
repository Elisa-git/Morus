using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
