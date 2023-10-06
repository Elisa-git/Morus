using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ListarUsuarios();
        Task<List<Usuario>> ListarUsuariosComCondominio();
        Task SalvarUsuario(Usuario usuario);
    }
}
