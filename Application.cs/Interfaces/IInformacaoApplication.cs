using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInformacaoApplication
    {
        Task AtualizarInformacao(Informacao informacaoMapeada);
        Task CadastrarInformacao(Informacao informacaoMapeada);
        Task DeletarInformacao(int id);
        Task<List<Informacao>> ListarInformacoesCondominio();
        Task<Informacao> ObterPorId(int id);
    }
}
