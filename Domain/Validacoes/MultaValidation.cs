using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validacoes
{
    internal class MultaValidation : AbstractValidator<Multa>
    {
        public DateTime dataAtual = DateTime.Now;

        public MultaValidation() 
        { 
            RuleFor(e => e.ValorMulta).NotEmpty().WithMessage("Informe o Valor da Multa");
            RuleFor(e => e.TaxaJurosDia).NotEmpty().WithMessage("Informe a Taxa de Juros da Multa");
            RuleFor(e => e.Id_usuario).NotEmpty().WithMessage("Informe o campo Usuario da Multa");
            RuleFor(e => e.AplicadaEm).NotEmpty().WithMessage("Informe a Data de aplicação da Multa");
            RuleFor(e => e.DataExpiracao).NotEmpty().WithMessage("Informe o Data final da Multa");
        }
    }
}
