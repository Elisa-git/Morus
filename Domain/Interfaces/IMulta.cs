using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IMulta : IGeneric<Multa>
    {
        Task<List<Multa>> ListarMessage(Expression<Func<Multa, bool>> exMessage);
    }
}