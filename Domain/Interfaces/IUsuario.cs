using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuario : IGeneric<Usuario>
    {
        Task<List<Usuario>> ListarMessage(Expression<Func<Usuario, bool>> exMessage);
    }
}