using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IEncomendaService
    {
        Task AtualizarEncomenda(Encomenda encomenda);
        Task CadastrarEncomenda(Encomenda encomenda);
        Task DeletarEncomenda(Encomenda encomenda);
        Task<List<Encomenda>> ListarEncomendas();
        Task<List<Encomenda>> ListarPorCondominio(int idCondominio);
    }
}
