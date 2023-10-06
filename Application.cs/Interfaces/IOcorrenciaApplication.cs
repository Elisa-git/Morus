using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOcorrenciaApplication
    {
        public Task CadastrarOcorrencia(Ocorrencia ocorrencia);
    }
}
