﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System.Diagnostics;

namespace SalesWebMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Mensagem"] = "Sistema de cadastro comercial.";
            ViewData["Email"] = "fabioluisgomes@gmail.com";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Página de Contato.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
