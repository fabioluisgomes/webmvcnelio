using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "{0} Tamanho deve ser maior que {2} e menor que {1}.") ]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} requerido.")]
        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAniversario { get; set; }
        
        [Required(ErrorMessage = "{0} requerido.")]
        [EmailAddress(ErrorMessage = "Entre com um E-mail válido.")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string E_mail { get; set; }


        [Required(ErrorMessage = "{0} requerido.")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve estar entre {1} e {2}.")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:f2}")]
        public double SalarioBase { get; set; }
        
        public Departamento Departamento { get; set; }
        [Display(Name = "ID Departamento")]
        public int DepartamentoId { get; set; }
        public ICollection<Venda> Vendas { get; set; }  = new List<Venda>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string e_mail, DateTime dataAniversario, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            E_mail = e_mail;
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
