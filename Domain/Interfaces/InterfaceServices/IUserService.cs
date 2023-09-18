using Entities.Entities;
using Entities.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IUserService
    {
        bool IsAllowed(List<TipoUsuario> tipoUsuarios, string token);

        
    }
}
