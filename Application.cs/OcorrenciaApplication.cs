using Application.Interfaces;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Application
{
    public class OcorrenciaApplication : IOcorrenciaApplication
    {
        private readonly IOcorrencia _ocorrenciaRepositorio;
        private readonly ValidatorBase<Ocorrencia> _ocorrenciaValidator;
        private readonly IOcorrenciaService _ocorrenciaService;
        private readonly IUserLogadoApplication _userLogadoApplication;

        public OcorrenciaApplication(IOcorrencia ocorrenciaRepositorio, INotificador notificador, IOcorrenciaService ocorrenciaService, IUserLogadoApplication userLogadoApplication)
        {
            _ocorrenciaRepositorio = ocorrenciaRepositorio;
            _ocorrenciaValidator = new ValidatorBase<Ocorrencia>(notificador);
            _ocorrenciaService = ocorrenciaService;
            _userLogadoApplication = userLogadoApplication;
        }
        public async Task CadastrarOcorrencia(Ocorrencia ocorrencia)
        {
            await _ocorrenciaService.SalvarOcorrencia(ocorrencia);
        }

        public async Task<List<Ocorrencia>> ListarOcorrencias()
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            
            return await _ocorrenciaRepositorio.ListarPorCondominio(userLogado.Id_condominio);
        }
    }
}
