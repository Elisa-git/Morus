using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IUsuario : IGeneric<Usuario>
    {
        Task<List<Usuario>> ListarMessage(Expression<Func<Usuario, bool>> exMessage);
        Task<List<Usuario>> ListarMessageIncludeCondominio(Expression<Func<Usuario, bool>> exMessage);
    }
}