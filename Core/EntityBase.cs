using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class EntityBase
    {
        [NotMapped]
        protected ValidationResult? ResultadoValidacao { get; set; }
        public abstract bool EhValido();
        public IEnumerable<string> GetErrorList() 
            => ResultadoValidacao?.Errors.Select(s => s.ErrorMessage);
    }
}
