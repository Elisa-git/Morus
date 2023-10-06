using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IAreaComumService
    {
        Task CadastrarAreaComum(AreaComum areaComumRequest);

        Task AtualizarAreaComum(AreaComum areaComumRequest);

    }
}
