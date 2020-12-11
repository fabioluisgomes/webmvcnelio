using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private ServicoDepartamento _servicoDepartamento { get; set; }

        public VendedoresController(ServicoVendedor servicoVendedor) // aula 254
        {
            _servicoVendedor = servicoVendedor;
        }

        public IActionResult Index() // aqui o index() é do tipo IActionResult que vai jogar para dentro da View a lista criada através do _servicoVendedor.ListarTudo().
        {
            var lista = _servicoVendedor.ListarTudo();
            return View(lista);
        }

        public IActionResult Criar()
        {
            var departamentos = _servicoDepartamento.BuscarTudo();
            var viewModel = new VendedorFormViewModel {Departamentos = departamentos }; // aula 257
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _servicoVendedor.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
