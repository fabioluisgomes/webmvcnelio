using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Venda
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
