using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVotacaoApplication
    {
        Task CadastrarVotacao(Votacao votacao);
        Task<VotacaoContadorResponse> ContadorVotacao(int idVotacao);
        Task DeletarVotacaoPorId(int id);
        Task<List<Votacao>> ListarVotacoesCondominio();
        Task<Votacao> ObterPorId(int id);
        Task RegistrarVoto(Voto voto);
    }
}
