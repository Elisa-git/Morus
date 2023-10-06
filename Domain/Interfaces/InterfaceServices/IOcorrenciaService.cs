using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IOcorrenciaService
    {
        Task SalvarOcorrencia(Ocorrencia ocorrencia);
    }
}
