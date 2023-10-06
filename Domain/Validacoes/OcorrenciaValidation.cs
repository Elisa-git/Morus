using Domain.Entities;
using FluentValidation;

namespace Domain.Validacoes
{
    public class OcorrenciaValidation : AbstractValidator<Ocorrencia>
    {
        public OcorrenciaValidation()
        {
            RuleFor(e => e.Titulo).NotEmpty().WithMessage("Título da ocorrência deve ser informado");
        }
    }
}
