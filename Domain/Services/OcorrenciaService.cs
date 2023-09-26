using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
