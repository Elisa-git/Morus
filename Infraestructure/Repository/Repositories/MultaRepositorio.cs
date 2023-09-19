using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Google.Protobuf;
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
    public class MultaRepositorio : RepositoryGenerics<Multa>, IMulta
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public MultaRepositorio() 
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Message>> ListarMessage(Expression<Func<Message, bool>> exMessage)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Message.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
