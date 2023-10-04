using Core;
using Core.Notificador;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Entities.Validacoes
{
    public class ValidatorBase<T> where T : EntityBase
    {
        private readonly INotificador _notificador;
        protected ValidationResult? ResultadoValidacao { get; set; }

        public ValidatorBase(INotificador notificador)
        {
            _notificador = notificador;
        }

        public bool ValidarEntidade(T entity)
        {
            if (entity.EhValido()) return true;

            foreach (var error in entity.GetErrorList())
                _notificador.Notificar(new Notificacao(error));

            return false;
        }
    }
}
