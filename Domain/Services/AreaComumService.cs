using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class AreaComumService : IAreaComumService
    {
        private readonly IAreaComumRepositorio areaComumRepositorio;
        private readonly INotificador notificador;
        private readonly ValidatorBase<AreaComum> areaComumValidator;

        public AreaComumService(IAreaComumRepositorio areaComumRepositorio, INotificador notificador)
        {
            this.areaComumRepositorio = areaComumRepositorio;
            this.notificador = notificador;
            this.areaComumValidator = new ValidatorBase<AreaComum>(notificador);
        }

        public async Task CadastrarAreaComum(AreaComum areaComumRequest)
        {
            if (!areaComumValidator.ValidarEntidade(areaComumRequest))
                throw new ValidacaoException();
            
            await areaComumRepositorio.Add(areaComumRequest);
        }

        public async Task AtualizarAreaComum(AreaComum areaComumRequest)
        {
            if (!areaComumValidator.ValidarEntidade(areaComumRequest))
                throw new ValidacaoException();

            if (areaComumRequest.Id == null)
            {
                this.notificador.Notificar("Informe o Id");
                throw new ValidacaoException();
            }
            
            await areaComumRepositorio.Update(areaComumRequest);

        }
        public async Task<List<AreaComum>> ListarAreaComum()
        {
            return await areaComumRepositorio.List();
        }
        public async Task<List<AreaComum>> ListarAreaComumPorCondominio(int idCondominio)
        {
            return await areaComumRepositorio.ListarAreasComuns(a => a.IdCondominio == idCondominio);
        }
    }
}