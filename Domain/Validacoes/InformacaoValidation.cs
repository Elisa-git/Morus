using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validacoes
{
    public class InformacaoValidation : AbstractValidator<Informacao>
    {
        public InformacaoValidation()
        {
            RuleFor(i => i.Id_condominio).NotEmpty().GreaterThan(0).WithMessage("Condomínio inválido para cadastro de informação");
        }
    }
}
