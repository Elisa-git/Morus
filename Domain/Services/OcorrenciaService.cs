using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrencia ocorrenciaGenerico;
        private readonly ValidatorBase<Ocorrencia> _ocorrenciaValidator;

        public OcorrenciaService(IOcorrencia ocorrenciaGenerico, INotificador notificador)
        {
            this.ocorrenciaGenerico = ocorrenciaGenerico;
            _ocorrenciaValidator = new ValidatorBase<Ocorrencia>(notificador);
        }

        public async Task SalvarOcorrencia(Ocorrencia ocorrencia)
        {
            if (!_ocorrenciaValidator.ValidarEntidade(ocorrencia))
                throw new ValidacaoException();

            await ocorrenciaGenerico.Add(ocorrencia);
        }

        public async Task AtualizarOcorrencia(Ocorrencia ocorrencia)
        {
            if (_ocorrenciaValidator.ValidarEntidade(ocorrencia))
                throw new ValidacaoException();

            await ocorrenciaGenerico.Update(ocorrencia);
        }

        public async Task DeletarOcorrencia(Ocorrencia ocorrencia)
        {
            await ocorrenciaGenerico.Delete(ocorrencia);
        }

        public async Task<List<Ocorrencia>> ListarOcorrencias()
        {
            return await ocorrenciaGenerico.List();
        }
    }
}
