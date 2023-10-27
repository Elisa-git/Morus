using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;

namespace Domain.Services
{
    public class MultaService : IMultaService
    {
        private readonly IMulta multaGenerico;
        private readonly INotificador notificador;
        private readonly ValidatorBase<Multa> multaValidator;
        private readonly IMulta multaRepositorio;

        public MultaService(
            IMulta multaGenerico, 
            INotificador notificador, 
            IMulta multaRepositorio
        )
        {
            this.multaGenerico = multaGenerico;
            this.notificador = notificador;
            this.multaValidator = new ValidatorBase<Multa>(notificador);
            this.multaRepositorio = multaRepositorio;
        }

        public async Task SalvarMulta(Multa multa)
        {
            if (!multaValidator.ValidarEntidade(multa))
                throw new ValidacaoException();
            
            await multaGenerico.Add(multa);
        }

        public async Task AtualizarMulta(Multa multaRequest)
        {
            var dataAtual = DateTime.Now;

            if (!multaValidator.ValidarEntidade(multaRequest))
                throw new ValidacaoException();

            if (multaRequest.Id == null)
            {
                this.notificador.Notificar("Informe o Id");
                throw new ValidacaoException();
            }

            await multaRepositorio.Update(multaRequest);
            
        }

        public async Task<List<Multa>> ListarMultas()
        {
            return await multaRepositorio.List();
        }
    }
}
