using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validacoes
{
    internal class AreaComumValidation : AbstractValidator<AreaComum>
    {
        public AreaComumValidation()
        {
            RuleFor(e => e.Limite).NotEmpty().WithMessage("Deve ser informado o limite"); 
            RuleFor(e => e.IdCondominio).NotEmpty().WithMessage("Deve ser informado o condominio"); 
            RuleFor(e => e.Nome).NotEmpty().WithMessage("Deve ser informado o nome da area"); 
        }
    }
}
