using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;

namespace Domain.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrencia ocorrenciaGenerico;

        public OcorrenciaService(IOcorrencia ocorrenciaGenerico)
        {
            this.ocorrenciaGenerico = ocorrenciaGenerico;
        }

        public async Task SalvarOcorrencia(Ocorrencia ocorrencia)
        {
            await ocorrenciaGenerico.Add(ocorrencia);
        }
    }
}
