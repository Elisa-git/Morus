using Application.Interfaces;
using Core.Exceptions;
using Core.Notificador;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Validacoes;
using Infraestructure.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
