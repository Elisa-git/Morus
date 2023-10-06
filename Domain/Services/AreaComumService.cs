using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;

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