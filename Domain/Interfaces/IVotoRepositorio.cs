using Domain.Entities;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVotoRepositorio : IGeneric<Voto>
    {
        Task<List<Voto>> ListarVotos(Expression<Func<Voto, bool>> exInformacao);
    }
}
