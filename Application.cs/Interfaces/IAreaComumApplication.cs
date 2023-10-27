using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAreaComumApplication
    {
        Task AtualizarAreaComum(AreaComum areaComumMapeada);
        Task CadastrarAreaComum(AreaComum areaComum);
        Task DeletarAreaComum(int id);
        Task<List<AreaComum>> ListarAreaComum();
        Task<AreaComum> ObterPorId(int id);
    }
}
