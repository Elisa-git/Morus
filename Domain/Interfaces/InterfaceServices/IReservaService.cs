using Domain.Entities;
using Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IReservaService
    {
        Task CadastrarReserva(Reserva reservaRequest);
        Task AtualizarReserva(Reserva reservaRequest, string userLogado);
        Task DeletarReserva(Reserva reservaRequest, string userLogado);
        Task<List<Reserva>> ListarReservas();
    }
}
