using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string mensagem) : base(mensagem) // recebo um parametro mensagem e faço a chamada para a classe base --> ApplicationException.
        {

        }
    }
}
