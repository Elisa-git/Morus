using Domain.Entities;
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
            RuleFor(l => l.Id_condominio).NotEmpty().GreaterThan(0).WithMessage("Id do condomínio deve ser informado");
        }
    }
}
