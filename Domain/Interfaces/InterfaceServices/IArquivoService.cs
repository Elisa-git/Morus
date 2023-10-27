using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IArquivoService
    {
        Task AtualizarArquivo(Arquivo arquivo);
        Task<byte[]> UploadArquivo(IFormFile documento);
        Task<MemoryStream> DownloadArquivo(int id);
        Task SalvarArquivo(Arquivo arquivo);
        Task DeletarArquivo(Arquivo arquivo);
        Task<List<Arquivo>> ListarArquivos();
    }
}
