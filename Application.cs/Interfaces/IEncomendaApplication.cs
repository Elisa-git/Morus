using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEncomendaApplication
    {
        Task AtualizarEncomenda(Encomenda encomenda);
        Task CadastrarEncomenda(Encomenda encomenda);
        Task DeletarEncomenda(int id);
        Task<List<Encomenda>> ListarEncomendas();
        Task<Encomenda> ObterPorId(int id);
    }
}
