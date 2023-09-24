using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Entities.Enum;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUser _User;
        

        public UserService(IUser IUser)
        {
            _User = IUser;
        }        

        public bool IsAllowed(List<TipoUsuario> tipoUsuarios, string token)
        {
            User userNow = _User.ListarUsers(x => x.Token == token).Result.SingleOrDefault();

            if (tipoUsuarios.Contains(userNow.Tipo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}