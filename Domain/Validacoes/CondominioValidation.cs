using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validacoes
{
    internal class CondominioValidation : AbstractValidator<Condominio>
    {
        public CondominioValidation()
        {
            RuleFor(e => e.Nome).NotEmpty().WithMessage("O nome do condominio deve ser informado");
            RuleFor(e => e.Porteiro).NotEmpty().WithMessage("O campo Porteiro deve ser informado");
        }
    }
}
