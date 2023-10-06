using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IInformacaoRepositorio : IGeneric<Informacao>
    {
        Task<List<Informacao>> ListarInformacoes(Expression<Func<Informacao, bool>> exInformacao);
    }
}
