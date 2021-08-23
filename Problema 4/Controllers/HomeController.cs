using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Problema_4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Problema_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public float Problema4(float kms, float litros){
            try
            {
                //Kms por litros: km/l
                return (kms / litros);
            }
            catch (DivideByZeroException)
            {
                return -9999;
            }
            catch (ArgumentException)
            {
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
