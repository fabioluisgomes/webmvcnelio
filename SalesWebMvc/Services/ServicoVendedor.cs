using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
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

        public void Inserir(Vendedor vend)
        {
            _context.Add(vend);
            _context.SaveChanges();
        }

        public Vendedor BuscarPorId(int id)
        {
            return _context.Vendedor.Include(vend => vend.Departamento).FirstOrDefault(vend => vend.Id == id); // Aula 259
        }

        public void Remover(int id)
        {
            var vend = _context.Vendedor.Find(id); // comando linq para buscar o vendedor por id.
            _context.Vendedor.Remove(vend); // apenas rewmovi do Dbset.
            _context.SaveChanges(); // agora informo ao entity para remover do banco de dados.
        }

        public void Atualizar(Vendedor vend)
        {
            if(!_context.Vendedor.Any(x => x.Id == vend.Id ))
            {
                throw new NotFoundException("Vendedor não encontrado.");
            }
            try
            {
                _context.Update(vend);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
