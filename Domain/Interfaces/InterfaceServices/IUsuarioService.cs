using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IUsuarioService
    {
        Task SalvarUsuario(Usuario usuario);
    }
}
