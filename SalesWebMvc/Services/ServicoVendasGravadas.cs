using SalesWebMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class ServicoVendasGravadas
    {
        private readonly SalesWebMvcContext _context;


        public ServicoVendasGravadas(SalesWebMvcContext context)
        {
            _context = context;
        }

    }
}
