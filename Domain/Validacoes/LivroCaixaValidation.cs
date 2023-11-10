using Domain.Entities;
using Domain.Entities.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validacoes
{
    public class LivroCaixaValidation : AbstractValidator<LivroCaixa>
    {
        public LivroCaixaValidation()
        {
            RuleFor(l => l.TipoTransacao).IsInEnum().WithMessage("Tipo Transação inválido");
        }
    }
}
