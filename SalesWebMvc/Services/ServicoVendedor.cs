using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class ServicoVendedor // Aula 254
    {
        private readonly SalesWebMvcContext _context;

        public ServicoVendedor(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> ListarTudo()
        {
            return _context.Vendedor.ToList();
        }

        public void Inserir(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
