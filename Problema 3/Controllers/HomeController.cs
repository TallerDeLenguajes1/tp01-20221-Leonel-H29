using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Problema_3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Problema_3.Entities;

namespace Problema_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Problema3() {

            // var url = $"https://apis.datos.gob.ar/georef/api/ubicacion?lat={lat}&lon={lon}";
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            List<Provincia> ListaProv;

            try
            {
                using WebResponse response = request.GetResponse();
                using Stream strReader = response.GetResponseStream();
                using StreamReader objReader = new(strReader);
                string respondeBody = objReader.ReadToEnd();
                ListaProv = System.Text.Json.JsonSerializer.Deserialize<ProvinciasArgentina>(respondeBody).Provincias;
            }
            catch (Exception e)
            {
                return View($"Error {e.Message}");

            }
            return View(ListaProv);
        }

        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
       

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
