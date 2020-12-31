using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class ServicoGravacaoVendas
    {
        private readonly SalesWebMvcContext _context; // banco de dados.

        public ServicoGravacaoVendas(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>> BuscarPorDataAsync(DateTime? minData, DateTime? maxData) // venda é o SalesRecord do curso.
        {
            var result = from vn in _context.Venda select vn; // obj criado com o linq. Venda é um dataset, então o linq cria um obj IQueryable.

            if (minData.HasValue)
            {
                result = result.Where(v => v.Data >= minData.Value); // posso também complementar 
            }
            if (maxData.HasValue)

            {
                result = result.Where(v => v.Data <= maxData.Value);
            }

            return await result
                .Include(v => v.Vendedor) //include, equivale ao join do SQL.
                .Include(v => v.Vendedor.Departamento)
                .OrderByDescending(v => v.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, Venda>>> BuscarPorDataAgrupadaAsync(DateTime? minData, DateTime? maxData) // venda é o SalesRecord do curso.
        {
            var result = from vn in _context.Venda select vn; // obj criado com o linq. Venda é um dataset, então o linq cria um obj IQueryable.

            if (minData.HasValue)
            {
                result = result.Where(v => v.Data >= minData.Value); // posso também complementar 
            }
            if (maxData.HasValue)

            {
                result = result.Where(v => v.Data <= maxData.Value);
            }

            return await result
                .Include(v => v.Vendedor) //include, equivale ao join do SQL.
                .Include(v => v.Vendedor.Departamento)
                .OrderByDescending(v => v.Data)
                .GroupBy(v => v.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}
