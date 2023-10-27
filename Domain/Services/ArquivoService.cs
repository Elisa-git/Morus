using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Domain.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepositorio arquivoRepositorio;
        private readonly INotificador notificador;
        private readonly ValidatorBase<Arquivo> _arquivoValidator;

        public ArquivoService(IArquivoRepositorio arquivoRepositorio, INotificador notificador)
        {
            this.arquivoRepositorio = arquivoRepositorio;
            this.notificador = notificador;
            _arquivoValidator = new ValidatorBase<Arquivo>(notificador);
        }

        public async Task<byte[]> UploadArquivo(IFormFile documento)
        {
            byte[] arquivoBytes;

            using (MemoryStream ms = new MemoryStream())
            {
                await documento.CopyToAsync(ms);
                arquivoBytes = ms.ToArray();
            }

            return arquivoBytes;
        }

        public async Task<MemoryStream> DownloadArquivo(int id)
        {
            Arquivo arquivoRecuperado = ListarArquivos().Result.FirstOrDefault(x => x.Id.Equals(id));

            byte[] myByteArray = arquivoRecuperado.Documento;
            MemoryStream stream = new MemoryStream(myByteArray);

            return stream;
        }

        public async Task SalvarArquivo(Arquivo arquivo)
        {
            if (!_arquivoValidator.ValidarEntidade(arquivo))
                throw new ValidacaoException();

            arquivo.DataUpload = DateTime.Now;
            await arquivoRepositorio.Add(arquivo);
        }

        public async Task AtualizarArquivo(Arquivo arquivo)
        {
            if (!_arquivoValidator.ValidarEntidade(arquivo))
                throw new ValidacaoException();

            await arquivoRepositorio.Update(arquivo);
        }

        public async Task DeletarArquivo(Arquivo arquivo)
        {
            await arquivoRepositorio.Delete(arquivo);
        }

        public async Task<List<Arquivo>> ListarArquivos()
        {
            return await arquivoRepositorio.List();
        }


    }
}
