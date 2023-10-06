using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

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
