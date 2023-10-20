using Domain.Entities;
using FluentValidation;

namespace Domain.Validacoes
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.CPF).NotEmpty().WithMessage("CPF deve ser informado");
            RuleFor(u => u.IdCondominio).NotEmpty().GreaterThan(0).WithMessage("Condominio deve ser informado");
        }
    }
}
