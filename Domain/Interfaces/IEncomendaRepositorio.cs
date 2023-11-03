using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IEncomendaRepositorio : IGeneric<Encomenda>
    {
        Task<List<Encomenda>> ListarQuery(Expression<Func<Encomenda, bool>> exEncomenda);
    }
}
