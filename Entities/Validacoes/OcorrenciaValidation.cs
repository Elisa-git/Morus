using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validacoes
{
    public class OcorrenciaValidation : AbstractValidator<Ocorrencia>
    {
        public OcorrenciaValidation()
        {
            RuleFor(e => e.Titulo).NotEmpty().WithMessage("Título da ocorrência deve ser informado");
        }
    }
}
