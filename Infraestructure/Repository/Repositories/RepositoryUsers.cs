using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
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
    public class RepositoryUsers : RepositoryGenerics<User>, IUser
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryUsers()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<User>> ListarUsers(Expression<Func<User, bool>> exUser)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.User.Where(exUser).AsNoTracking().ToListAsync();
            }
        }
    }
}
