using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IAreaComumService
    {
        Task CadastrarAreaComum(AreaComum areaComumRequest);
        Task<List<AreaComum>> ListarAreaComum();
        Task AtualizarAreaComum(AreaComum areaComumRequest);
        Task<List<AreaComum>> ListarAreaComumPorCondominio(int idCondominio);
    }
}
