using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Problema_2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Problema_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public float Problema2(int a, int b)
        {
            try {
                return a / b;
            }
            catch (DivideByZeroException)
            {
                /*Mando un valor por defecto 
                 en caso de que halla una division por 0*/
                return -9999;
            }
            
        }


        public IActionResult Index()
        {
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
