using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private ServicoDepartamento _servicoDepartamento { get; set; }

        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento) // aula 254
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento;
        }

        public async Task<IActionResult> Index() // aqui o index() é do tipo IActionResult que vai jogar para dentro da View a lista criada através do _servicoVendedor.ListarTudo().
        {
            var lista = await _servicoVendedor.ListarTudoAsync();
            return View(lista);
        }

        public async Task<IActionResult> Criar()
        {
            var departamentos = await _servicoDepartamento.BuscarTudoAsync();
            var viewModel = new VendedorFormViewModel {Departamentos = departamentos}; // aula 257
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var depart = await _servicoDepartamento.BuscarTudoAsync();
                var viewModelDepar = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = depart };
                return View(viewModelDepar);
            }

            var departamentos = await _servicoDepartamento.BuscarTudoAsync();
            var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
            await _servicoVendedor.InserirAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Apagar(int? id) // retorna tela Apagar.cshtml com os dados do Vendedor que será apagado. O nome da ação apagar e a tela, devem ser iguais.
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Id não fornecido"}); // depois vou personalizar com uma página de erro.
            }

            var vend = await _servicoVendedor.BuscarPorIdAsync(id.Value); // como o parametro é opcional, tenho que pegar o value desse parâmetro.

            if(vend == null) // caso o vendedor não exista, então retorno uma página de erro.
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Vendedor não encontrado"});
            }
            // este método Apagar, não é a ação de apagar em si, ele trás uma tela perguntando se quero apagar o registro ou não.
            return View(vend); // se tudo der certo, então retorno uma view enviando vendedor (id) como argumento.
        }

        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            await _servicoVendedor.RemoverAsync(id);
            return RedirectToAction(nameof(Index)); // redireciona para tela de index do vendedor.

        }


        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Id não fornecido."});
            }
            var vend = await _servicoVendedor.BuscarPorIdAsync(id.Value);
            if (vend == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Vendedor não encontrado."});
            }
            return View(vend);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Id não fornecido." });
            }

            var vend = await _servicoVendedor.BuscarPorIdAsync(id.Value);
            if(vend == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Vendedor não encontrado."});
            }

            List<Departamento> departamentos = await _servicoDepartamento.BuscarTudoAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = vend, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar (int id, Vendedor vendedor) // id vem da requisição.
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _servicoDepartamento.BuscarTudoAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id da URL não corresponde." }); ;
            }
            try
            {
                await _servicoVendedor.AtualizarAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = e.Message });
            }
        }

        public IActionResult Erro(string mensagem)
        {
            var viewModel = new ErrorViewModel
            {
                Mensagem = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier // macete pra pegar o id interno da requisição.
            };
            return View(viewModel);
        }
    }
}
