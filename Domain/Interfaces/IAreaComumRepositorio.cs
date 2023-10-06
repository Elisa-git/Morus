using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IAreaComumRepositorio : IGeneric<AreaComum>
    {
        Task<List<AreaComum>> ListarAreasComuns(Expression<Func<AreaComum, bool>> exAreaComum);
    }
}
