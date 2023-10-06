using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IOcorrenciaService
    {
        Task AtualizarOcorrencia(Ocorrencia ocorrencia);
        Task DeletarOcorrencia(Ocorrencia ocorrencia);
        Task<List<Ocorrencia>> ListarOcorrencias();
        Task SalvarOcorrencia(Ocorrencia ocorrencia);
    }
}
