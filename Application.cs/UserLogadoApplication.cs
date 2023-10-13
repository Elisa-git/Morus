using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UserLogadoApplication : IUserLogadoApplication
    {
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly IUsuario _usuarioRepository;

        public UserLogadoApplication(IHttpContextAccessor httpAccessor, IUsuario usuarioRepository)
        {
            _httpAccessor = httpAccessor;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> ObterUsuarioLogado()
        {
            var idUsuarioLogado = _httpAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type.Equals("idUsuario", StringComparison.InvariantCultureIgnoreCase))?.Value;
            return (await _usuarioRepository.ListarMessage(w => w.IdUserIdentity.Equals(idUsuarioLogado)))?.FirstOrDefault();
        }
    }
}
