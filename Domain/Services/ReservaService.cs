using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepositorio reservaRepositorio;
        private readonly ValidatorBase<Reserva> reservaValidator;
        private readonly IUsuarioService usuarioServico;

        public ReservaService(
            IReservaRepositorio reservaRepositorio,
            IUsuarioService usuarioServico,
            INotificador notificador
        )
        {
            this.reservaRepositorio = reservaRepositorio;
            this.reservaValidator = new ValidatorBase<Reserva>(notificador);
            this.usuarioServico = usuarioServico;
        }

        public async Task CadastrarReserva(Reserva reservaRequest)
        {
            var data = ZerarTimeStamp(reservaRequest.DataReserva);
            reservaRequest.DataReserva = data;

            if (!reservaValidator.ValidarEntidade(reservaRequest))
                throw new ValidacaoException();

            if (!UsuarioExiste(reservaRequest))
                throw new ValidacaoException("O morador informado não existe");
            
            if (ValidarDisponibilidadeReserva(reservaRequest))
                throw new ValidacaoException("Já existem reservas para esse local nesta data");

            reservaRequest.DataCadastro = DateTime.Now;
            reservaRequest.DataAlteracao = DateTime.Now;
            reservaRequest.Ativo = true;
            await reservaRepositorio.Add(reservaRequest);
        }

        public async Task AtualizarReserva(Reserva reservaRequest, string userLogado)
        {
            var data = ZerarTimeStamp(reservaRequest.DataReserva);
            reservaRequest.DataReserva = data;

            if (!reservaValidator.ValidarEntidade(reservaRequest))
                throw new ValidacaoException();

            if (!ValidarDonoReserva(reservaRequest) || userLogado.Equals(TipoUsuario.Sindico.ToString()) || userLogado.Equals(TipoUsuario.Admin.ToString()))
                throw new ValidacaoException("Somente o dono da reserva e o síndico podem fazer alterações");

            if (!UsuarioExiste(reservaRequest))
                throw new ValidacaoException("O morador informado não existe");

            if (ValidarDisponibilidadeReserva(reservaRequest))
                throw new ValidacaoException("Já existem reservas para esse local nesta data");

            reservaRequest.DataAlteracao = DateTime.Now;
            await reservaRepositorio.Update(reservaRequest);
        }

        public async Task DeletarReserva(Reserva reservaRequest, string userLogado)
        {
            if (!ValidarDonoReserva(reservaRequest) || userLogado.Equals(TipoUsuario.Sindico.ToString()) || userLogado.Equals(TipoUsuario.Admin.ToString()))
                throw new ValidacaoException("Somente o dono da reserva e o síndico podem excluir a Reserva");

            await reservaRepositorio.Delete(reservaRequest);
        }

        public async Task<List<Reserva>> ListarReservas()
        {
            return await reservaRepositorio.List();
        }

        private bool ValidarDonoReserva(Reserva reservaRequest)
        {
            return ListarReservas().Result.Any(x => x.Id.Equals(reservaRequest.Id) && x.Id_Usuario.Equals(reservaRequest.Id_Usuario));
        }

        private bool ValidarDisponibilidadeReserva(Reserva reserva)
        {
            var listaReserva = ListarReservas().Result;
            if (listaReserva.Count > 0)
                return listaReserva.Any(x => x.DataReserva.Equals(reserva.DataReserva) && x.Id_AreaComum.Equals(reserva.Id_AreaComum));
            
            return true;
        }

        private bool UsuarioExiste(Reserva reservaRequest)
        {
            return usuarioServico.ListarUsuarios().Result.Any(x => x.Id.Equals(reservaRequest.Id_Usuario));
        }

        private DateTime ZerarTimeStamp(DateTime data)
        {
            var newData = new DateTime();
            newData = data.Date;

            return newData;
        }

    }
}
