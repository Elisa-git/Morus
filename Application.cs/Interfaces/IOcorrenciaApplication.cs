using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IOcorrenciaApplication
    {
        public Task CadastrarOcorrencia(Ocorrencia ocorrencia);
        Task DeletarOcorrencia(int id);
        public Task<List<Ocorrencia>> ListarOcorrencias();
        Task<List<Ocorrencia>> ListarOcorrenciasFiltro(bool resolvido);
    }
}
