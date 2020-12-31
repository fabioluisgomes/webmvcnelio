using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class VendasGravadasController : Controller
    {

        private readonly ServicoGravacaoVendas _servicoGravacaoVendas;

        public VendasGravadasController(ServicoGravacaoVendas servicoGravacaoVendas)
        {
            _servicoGravacaoVendas = servicoGravacaoVendas;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? minData, DateTime? maxData)
        {

            if(!minData.HasValue)
            {
                minData = new DateTime(DateTime.Now.Year, 1, 1);
            }


            if (!maxData.HasValue)
            {
                maxData = DateTime.Now;
            }

            ViewData["minData"] = minData.Value.ToString("yyyy-MM-dd");
            ViewData["maxData"] = maxData.Value.ToString("yyyy-MM-dd");

            var result  = await _servicoGravacaoVendas.BuscarPorDataAsync(minData, maxData);
            return View(result);
        }

        public async Task<IActionResult> BuscaAgrupada(DateTime? minData, DateTime? maxData)
        {
            if (!minData.HasValue)
            {
                minData = new DateTime(DateTime.Now.Year, 1, 1);
            }


            if (!maxData.HasValue)
            {
                maxData = DateTime.Now;
            }

            ViewData["minData"] = minData.Value.ToString("yyyy-MM-dd");
            ViewData["maxData"] = maxData.Value.ToString("yyyy-MM-dd");

            var result = await _servicoGravacaoVendas.BuscarPorDataAgrupadaAsync(minData, maxData);
            return View(result);
        }
    }
}
