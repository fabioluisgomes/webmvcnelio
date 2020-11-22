using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public DateTime DataAniversario { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Venda> Vendas { get; set; }  = new List<Venda>();

        public Vendedor()
        {

        }

        public Vendedor(int id, int nome, DateTime dataAniversario, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            DataAniversario = dataAniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVendas(Venda venda)
        {
            Vendas.Add(venda);
        }

        public void RemoveVendas(Venda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas(DateTime inicio, DateTime final)
        {
            return Vendas.Where(vd => vd.Data >= inicio && vd.Data <= final).Sum(vd => vd.Montante);
        }
    }
}
