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
    public class UsuarioRepositorio : RepositoryGenerics<Usuario>, IUsuario
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public UsuarioRepositorio() 
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Usuario>> ListarMessage(Expression<Func<Usuario, bool>> exMessage)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Usuario.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
