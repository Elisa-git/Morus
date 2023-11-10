using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validacoes
{
    internal class TaxaMensalValidation : AbstractValidator<TaxaMensal>
    {
        public TaxaMensalValidation()
        {
            RuleFor(e => e.Nome).NotEmpty().WithMessage("O campo Nome deve ser informado");
            RuleFor(e => e.Valor).NotEmpty().WithMessage("O campo Valor deve ser informado");
            RuleFor(e => e.Recorrente).NotNull().WithMessage("O campo Recorrente deve ser informado");
            RuleFor(e => e.DataInicio).NotEmpty().WithMessage("O campo Data Inicio deve ser informado");
            RuleFor(e => e.DataFim).NotEmpty().WithMessage("O campo Data Fim deve ser informado");
            RuleFor(e => e.IdCondominio).NotEmpty().WithMessage("O campo Id Condominio deve ser informado");
        }
    }
}
