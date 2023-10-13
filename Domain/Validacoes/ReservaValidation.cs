using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validacoes
{
    internal class ReservaValidation : AbstractValidator<Reserva>
    {
        public ReservaValidation()
        {
            RuleFor(e => e.Id_Usuario).NotEmpty().WithMessage("O Responsável pela reserva deve ser informado");
            RuleFor(e => e.Id_AreaComum).NotEmpty().WithMessage("O Local reservado deve ser informado");
            RuleFor(e => e.DataReserva).NotEmpty().WithMessage("A data da reserva deve ser informado");
        }
    }
}
