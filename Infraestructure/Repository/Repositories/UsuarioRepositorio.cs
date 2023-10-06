using Domain.Entities;
using Domain.Interfaces;
using Google.Protobuf;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<List<Usuario>> ListarMessageIncludeCondominio(Expression<Func<Usuario, bool>> exMessage)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Usuario.AsNoTracking().Where(exMessage).Include(u => u.Condominio).ToListAsync();
            }
        }

        public async Task<List<Usuario>> ListarComCondominio()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Usuario.AsNoTracking().Include(u => u.Condominio).ToListAsync();
            }
        }
    }
}
