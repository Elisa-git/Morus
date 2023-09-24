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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuario _Usuario;
        

        public UsuarioService(IUsuario IUsuario)
        {
            _Usuario = IUsuario;
        }

        public void CreateUsuario(Usuario usuario)
        {
            _Usuario.Add(usuario);
        }


    }
}