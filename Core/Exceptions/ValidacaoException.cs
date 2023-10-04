using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string? message) : base(message)
        {
        }

        public ValidacaoException()
        {

        }
    }
}
