using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class ServicoDepartamento
    {

        private readonly SalesWebMvcContext _context;
        public ServicoDepartamento(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> BuscarTudo()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
            //return _context.Departamento.ToList();
        }
    }
}
