using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ILivroCaixaRepositorio : IGeneric<LivroCaixa>
    {
        Task<List<LivroCaixa>> ListarQuery(Expression<Func<LivroCaixa, bool>> exLivroCaixa);
    }
}
