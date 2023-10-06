using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;

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

        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await usuarioGenerico.List();
        }

        public async Task<List<Usuario>> ListarUsuariosComCondominio()
        {
            return await usuarioGenerico.ListarComCondominio();
        }
    }
}
