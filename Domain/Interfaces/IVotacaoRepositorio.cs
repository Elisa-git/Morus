using Domain.Entities;
using Domain.Interfaces.Generics;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IVotacaoRepositorio : IGeneric<Votacao>
    {
        Task<List<Votacao>> ListarVotacoes(Expression<Func<Votacao, bool>> exInformacao);
    }
}
