using Application.Interfaces;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;

namespace Application
{
    public class AreaComumApplication : IAreaComumApplication
    {
        private readonly IAreaComumService _areaComumService;
        private readonly INotificador _notificador;
        private readonly IUserLogadoApplication _userLogadoApplication;
        private readonly IAreaComumRepositorio _areaComumRepo;

        public AreaComumApplication(IAreaComumService areaComumService, INotificador notificador, IUserLogadoApplication userLogadoApplication, IAreaComumRepositorio areaComumRepo)
        {
            _areaComumService = areaComumService;
            _notificador = notificador;
            _userLogadoApplication = userLogadoApplication;
            _areaComumRepo = areaComumRepo;
        }

        public async Task AtualizarAreaComum(AreaComum areaComum)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            areaComum.IdCondominio = usuarioLogado.IdCondominio;

            await _areaComumService.AtualizarAreaComum(areaComum);

        }

        public async Task CadastrarAreaComum(AreaComum areaComum)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            areaComum.IdCondominio = usuarioLogado.IdCondominio;

            await _areaComumService.CadastrarAreaComum(areaComum);
        }

        public async Task DeletarAreaComum(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var areaComum = await ObterPorId(id);

            await _areaComumRepo.Delete(areaComum);
        }

        public async Task<List<AreaComum>> ListarAreaComum()
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();

            return await _areaComumService.ListarAreaComumPorCondominio(usuarioLogado.IdCondominio);
        }


        public async Task<AreaComum> ObterPorId(int id)
        {
            var userLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var areaComum = await _areaComumRepo.GetEntityById(id);

            if (areaComum == null)
            {
                _notificador.Notificar("Area comum inexistente.");
                throw new ValidacaoException("");
            }
            if (areaComum.IdCondominio != userLogado.IdCondominio)
            {
                _notificador.Notificar("Usuário não tem permissão para acessar area comum solicitada.");
                throw new InvalidOperationException();
            }

            return areaComum;
        }
    }
}
