using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOcorrenciaApplication
    {
        public Task CadastrarOcorrencia(Ocorrencia ocorrencia);
        Task DeletarOcorrencia(int id);
        public Task<List<Ocorrencia>> ListarOcorrencias();
    }
}
