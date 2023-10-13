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
        Task<List<Votacao>> ListarVotacoesCondominio();
        Task RegistrarVoto(Voto voto);
    }
}
