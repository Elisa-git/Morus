using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuario usuarioGenerico;

        public UsuarioService(IUsuario usuarioGenerico)
        {
            this.usuarioGenerico = usuarioGenerico;
        }

        public async Task SalvarUsuario(Usuario usuario)
        {
            await usuarioGenerico.Add(usuario);
        }
    }
}
