using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Montante { get; set; }
        public SituacaoVenda Situacao { get; set; }
        public Vendedor Vendedor { get; set; }

        public Venda()

        {

        }

        public Venda(int id, DateTime data, double montante, SituacaoVenda situacao, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Montante = montante;
            Situacao = situacao;
            Vendedor = vendedor;
        }
    }
}
