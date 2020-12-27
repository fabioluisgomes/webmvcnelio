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

        public async Task<List<Vendedor>> ListarTudoAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InserirAsync(Vendedor vend)
        {
            _context.Add(vend);
           await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> BuscarPorIdAsync(int id)
        {
            return await _context.Vendedor.Include(vend => vend.Departamento).FirstOrDefaultAsync(vend => vend.Id == id); // Aula 259
        }

        public async Task RemoverAsync(int id)
        {
            try
            {
                var vend = await _context.Vendedor.FindAsync(id); // comando linq para buscar o vendedor por id.
                _context.Vendedor.Remove(vend); // apenas rewmovi do Dbset.
                await _context.SaveChangesAsync(); // agora informo ao entity para remover do banco de dados.
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException("Não foi possível remover o vendedor, ele possui vendas.");
            }
        }

        public async Task AtualizarAsync(Vendedor vend)
        {
            bool temAlgum = await _context.Vendedor.AnyAsync(x => x.Id == vend.Id);
            if (!temAlgum)
            {
                throw new NotFoundException("Vendedor não encontrado.");
            }
            try
            {
                _context.Update(vend);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
