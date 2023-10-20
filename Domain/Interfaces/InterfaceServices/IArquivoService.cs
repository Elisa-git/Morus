using Domain.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IArquivoService
    {
        Task AtualizarArquivo(Arquivo arquivo);
        Task CadastrarArquivo(Arquivo arquivo);
        Task DeletarArquivo(Arquivo arquivo);
        Task<List<Arquivo>> ListarArquivos();
    }
}
