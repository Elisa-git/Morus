using Application.Interfaces;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Validacoes;

namespace Application
{
    public class OcorrenciaApplication : IOcorrenciaApplication
    {
        private readonly IOcorrencia _ocorrenciaRepositorio;
        private readonly ValidatorBase<Ocorrencia> _ocorrenciaValidator;

        public OcorrenciaApplication(IOcorrencia ocorrenciaRepositorio, INotificador notificador)
        {
            _ocorrenciaRepositorio = ocorrenciaRepositorio;
            _ocorrenciaValidator = new ValidatorBase<Ocorrencia>(notificador);
        }
        public async Task CadastrarOcorrencia(Ocorrencia ocorrencia)
        {
            if (_ocorrenciaValidator.ValidarEntidade(ocorrencia))
                throw new ValidacaoException();

            await _ocorrenciaRepositorio.Add(ocorrencia);
        }


    }
}
