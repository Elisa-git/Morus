using Application.Interfaces;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;
using System.Linq;
using System.Linq.Expressions;

namespace Application
{
    public class OcorrenciaApplication : IOcorrenciaApplication
    {
        private readonly IOcorrencia _ocorrenciaRepositorio;
        private readonly ValidatorBase<Ocorrencia> _ocorrenciaValidator;
        private readonly IOcorrenciaService _ocorrenciaService;
        private readonly IUserLogadoApplication _userLogadoApplication;
        private readonly INotificador _notificador;

        public OcorrenciaApplication(IOcorrencia ocorrenciaRepositorio, INotificador notificador, IOcorrenciaService ocorrenciaService, IUserLogadoApplication userLogadoApplication)
        {
            _ocorrenciaRepositorio = ocorrenciaRepositorio;
            _ocorrenciaValidator = new ValidatorBase<Ocorrencia>(notificador);
            _ocorrenciaService = ocorrenciaService;
            _userLogadoApplication = userLogadoApplication;
            _notificador = notificador;
        }
        public async Task CadastrarOcorrencia(Ocorrencia ocorrencia)
        {
            await _ocorrenciaService.SalvarOcorrencia(ocorrencia);
        }

        public async Task<List<Ocorrencia>> ListarOcorrencias()
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();

            return await _ocorrenciaRepositorio.ListarPorCondominio(userLogado.IdCondominio);
        }

        public async Task<List<Ocorrencia>> ListarOcorrenciasFiltro(bool resolvido)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();

            return await _ocorrenciaRepositorio.ListarPorCondominioMessage(userLogado.IdCondominio, o => o.Resolvido == resolvido);
        }


        public async Task DeletarOcorrencia(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var ocorrencia = await _ocorrenciaRepositorio.GetEntityById(id);

            if (ocorrencia == null)
            {
                _notificador.Notificar("Ocorrência inexistente.");
                throw new ValidacaoException("");
            }

            await _ocorrenciaService.DeletarOcorrencia(ocorrencia);
        }
    }
}
