using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AreaComumService : IAreaComumService
    {
        private readonly IAreaComumRepositorio areaComumRepositorio;

        public AreaComumService(IAreaComumRepositorio areaComumRepositorio)
        {
            this.areaComumRepositorio = areaComumRepositorio;
        }

        public async Task CadastrarAreaComum(AreaComum areaComumRequest)
        {
            var validanome = areaComumRequest.ValidarPropriedadeString(areaComumRequest.Nome, "Nome");
            if (validanome)
            {
                await areaComumRepositorio.Add(areaComumRequest);
            }
        }

        public async Task AtualizarAreaComum(AreaComum areaComumRequest)
        {
            var validanome = areaComumRequest.ValidarPropriedadeString(areaComumRequest.Nome, "Nome");
            if (validanome)
            {
                await areaComumRepositorio.Update(areaComumRequest);
            }
        }
    }
}