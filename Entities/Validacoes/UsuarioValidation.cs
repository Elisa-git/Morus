using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validacoes
{
    public class UsuarioValidation : AbstractValidator<Usuario> 
    {
        public UsuarioValidation() 
        {
            RuleFor(u => u.CPF).NotEmpty().WithMessage("CPF deve ser informado");
        }
    }
}
