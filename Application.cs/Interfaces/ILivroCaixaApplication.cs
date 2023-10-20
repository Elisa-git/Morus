using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILivroCaixaApplication
    {
        Task AtualizarLivroCaixa(LivroCaixa livroCaixa);
        Task CadastrarLivroCaixa(LivroCaixa livroCaixa);
        Task DeletarLivroCaixa(int id);
        Task<List<LivroCaixa>> ListarLivroCaixas();
        Task<LivroCaixa> ObterPorId(int id);
    }
}
