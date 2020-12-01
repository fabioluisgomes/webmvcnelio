using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class PopularServico // aula 252
    {
        private SalesWebMvcContext _context { get; set; }

        public PopularServico(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Popular()
        {
            if(_context.Departamento.Any() ||
                _context.Vendedor.Any() ||
                _context.Venda.Any())
            {
                return; // BD já foi populado. O return apenas é executado caso alguma tabela tenha informação.
            }

            
            Departamento d1 = new Departamento(1, "Computers");
            Departamento d2 = new Departamento(2, "Electronics");
            Departamento d3 = new Departamento(3, "Fashion");
            Departamento d4 = new Departamento(4, "Books");

            Vendedor v1 = new Vendedor(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor v2 = new Vendedor(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedor v3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Vendedor v4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedor v5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Vendedor v6 = new Vendedor(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            Venda vd1 = new Venda(1, new DateTime(2018, 09, 25), 11000.0, SituacaoVenda.Pago, v1);
            Venda vd2 = new Venda(2, new DateTime(2018, 09, 4), 7000.0, SituacaoVenda.Pago, v5);
            Venda vd3 = new Venda(3, new DateTime(2018, 09, 13), 4000.0, SituacaoVenda.Cancelada, v4);
            Venda vd4 = new Venda(4, new DateTime(2018, 09, 1), 8000.0, SituacaoVenda.Pago, v1);
            Venda vd5 = new Venda(5, new DateTime(2018, 09, 21), 3000.0, SituacaoVenda.Pago, v3);
            Venda vd6 = new Venda(6, new DateTime(2018, 09, 15), 2000.0, SituacaoVenda.Pago, v1);
            Venda vd7 = new Venda(7, new DateTime(2018, 09, 28), 13000.0, SituacaoVenda.Pago, v2);
            Venda vd8 = new Venda(8, new DateTime(2018, 09, 11), 4000.0, SituacaoVenda.Pago, v4);
            Venda vd9 = new Venda(9, new DateTime(2018, 09, 14), 11000.0, SituacaoVenda.Pendente, v6);
            Venda vd10 = new Venda(10, new DateTime(2018, 09, 7), 9000.0, SituacaoVenda.Pago, v6);
            Venda vd11 = new Venda(11, new DateTime(2018, 09, 13), 6000.0, SituacaoVenda.Pago, v2);
            Venda vd12 = new Venda(12, new DateTime(2018, 09, 25), 7000.0, SituacaoVenda.Pendente, v3);
            Venda vd13 = new Venda(13, new DateTime(2018, 09, 29), 10000.0, SituacaoVenda.Pago, v4);
            Venda vd14 = new Venda(14, new DateTime(2018, 09, 4), 3000.0, SituacaoVenda.Pago, v5);
            Venda vd15 = new Venda(15, new DateTime(2018, 09, 12), 4000.0, SituacaoVenda.Pago, v1);
            Venda vd16 = new Venda(16, new DateTime(2018, 10, 5), 2000.0, SituacaoVenda.Pago, v4);
            Venda vd17 = new Venda(17, new DateTime(2018, 10, 1), 12000.0, SituacaoVenda.Pago, v1);
            Venda vd18 = new Venda(18, new DateTime(2018, 10, 24), 6000.0, SituacaoVenda.Pago, v3);
            Venda vd19 = new Venda(19, new DateTime(2018, 10, 22), 8000.0, SituacaoVenda.Pago, v5);
            Venda vd20 = new Venda(20, new DateTime(2018, 10, 15), 8000.0, SituacaoVenda.Pago, v6);
            Venda vd21 = new Venda(21, new DateTime(2018, 10, 17), 9000.0, SituacaoVenda.Pago, v2);
            Venda vd22 = new Venda(22, new DateTime(2018, 10, 24), 4000.0, SituacaoVenda.Pago, v4);
            Venda vd23 = new Venda(23, new DateTime(2018, 10, 19), 11000.0, SituacaoVenda.Cancelada, v2);
            Venda vd24 = new Venda(24, new DateTime(2018, 10, 12), 8000.0, SituacaoVenda.Pago, v5);
            Venda vd25 = new Venda(25, new DateTime(2018, 10, 31), 7000.0, SituacaoVenda.Pago, v3);
            Venda vd26 = new Venda(26, new DateTime(2018, 10, 6), 5000.0, SituacaoVenda.Pago, v4);
            Venda vd27 = new Venda(27, new DateTime(2018, 10, 13), 9000.0, SituacaoVenda.Pendente, v1);
            Venda vd28 = new Venda(28, new DateTime(2018, 10, 7), 4000.0, SituacaoVenda.Pago, v3);
            Venda vd29 = new Venda(29, new DateTime(2018, 10, 23), 12000.0, SituacaoVenda.Pago, v5);
            Venda vd30 = new Venda(30, new DateTime(2018, 10, 12), 5000.0, SituacaoVenda.Pago, v2);

            _context.Departamento.AddRange(d1, d2, d3, d4);

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);

            _context.Venda.AddRange(
                vd1, vd2, vd3, vd4, vd5, vd6, vd7, vd8, vd9, vd10,
                vd11, vd12, vd13, vd14, vd15, vd16, vd17, vd18, vd19, vd20,
                vd21, vd22, vd23, vd24, vd25, vd26, vd27, vd28, vd29, vd30
            );

            _context.SaveChanges();
        }
    }
}
