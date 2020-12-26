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

        public IActionResult Index() // aqui o index() é do tipo IActionResult que vai jogar para dentro da View a lista criada através do _servicoVendedor.ListarTudo().
        {
            var lista = _servicoVendedor.ListarTudo();
            return View(lista);
        }

        public IActionResult Criar()
        {
            var departamentos = _servicoDepartamento.BuscarTudo();
            var viewModel = new VendedorFormViewModel {Departamentos = departamentos}; // aula 257
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            var departamentos = _servicoDepartamento.BuscarTudo();
            var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
            _servicoVendedor.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Apagar(int? id) // retorna tela Apagar.cshtml com os dados do Vendedor que será apagado. O nome da ação apagar e a tela, devem ser iguais.
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Id não fornecido"}); // depois vou personalizar com uma página de erro.
            }

            var vend = _servicoVendedor.BuscarPorId(id.Value); // como o parametro é opcional, tenho que pegar o value desse parâmetro.

            if(vend == null) // caso o vendedor não exista, então retorno uma página de erro.
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Vendedor não encontrado"});
            }
            // este método Apagar, não é a ação de apagar em si, ele trás uma tela perguntando se quero apagar o registro ou não.
            return View(vend); // se tudo der certo, então retorno uma view enviando vendedor (id) como argumento.
        }

        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public IActionResult Apagar(int id)
        {
            _servicoVendedor.Remover(id);
            return RedirectToAction(nameof(Index)); // redireciona para tela de index do vendedor.

        }


        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Id não fornecido."});
            }
            var vend = _servicoVendedor.BuscarPorId(id.Value);
            if (vend == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Vendedor não encontrado."});
            }
            return View(vend);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Id não fornecido." });
            }

            var vend = _servicoVendedor.BuscarPorId(id.Value);
            if(vend == null)
            {
                return RedirectToAction(nameof(Erro), new {mensagem = "Vendedor não encontrado."});
            }

            List<Departamento> departamentos = _servicoDepartamento.BuscarTudo();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = vend, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar (int id, Vendedor vendedor) // id vem da requisição.
        {
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id da URL não corresponde." }); ;
            }
            try
            {
                _servicoVendedor.Atualizar(vendedor);
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
