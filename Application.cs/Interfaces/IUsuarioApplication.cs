using Application.NovaPasta1;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task Cadastrar(Usuario usuario);
        Task<bool> CadastrarMorador(User userIdentity, Usuario usuarioSistema);
        Task<UsuarioLoginResponse> ObterDadosUsuarioLogin(string idUsuarioIdentity);
    }
}
