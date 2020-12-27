using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class ServicoDepartamento
    {

        private readonly SalesWebMvcContext _context;
        public ServicoDepartamento(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> BuscarTudoAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
            //return _context.Departamento.ToList();
        }
    }
}
