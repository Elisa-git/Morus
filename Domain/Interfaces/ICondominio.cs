using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ICondominio : IGeneric<Condominio>
    {
        Task<List<Message>> ListarMessage(Expression<Func<Message, bool>> exMessage);
    }
}
