using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IOcorrencia : IGeneric<Ocorrencia>
    {
        Task<List<Ocorrencia>> ListarMessage(Expression<Func<Ocorrencia, bool>> exMessage);
        Task<List<Ocorrencia>> ListarPorCondominio(int idCondominio);
    }
}