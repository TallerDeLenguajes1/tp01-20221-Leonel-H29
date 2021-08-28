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

namespace Problema_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public static void Problema3() {

            // var url = $"https://apis.datos.gob.ar/georef/api/ubicacion?lat={lat}&lon={lon}";
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
 
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ProvinciasArgentina ListProvincias = JsonSerializer.Deserialize<ProvinciasArgentina>(responseBody);
                            //string[] array_Provincias = new string[ListProvincias.Cantidad];
                            //int i = 0;
                            foreach (Provincia Prov in ListProvincias.Provincias)
                            {
                                //Console.WriteLine("id: " + Prov.Id + " Nombre: " + Prov.Nombre);
                                //array_Provincias[i] = "id: " + Prov.Id + " Nombre: " + Prov.Nombre;
                            }

                        }
                    }
                }
            }
            catch (Exception )
            {
                // Handle error
            }
        }

        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Parametros
        {
            [JsonPropertyName("campos")]
            public List<string> Campos { get; set; }
        }

        public class Provincia
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("nombre")]
            public string Nombre { get; set; }
        }
        public class ProvinciasArgentina
        {
            [JsonPropertyName("cantidad")]
            public int Cantidad { get; set; }

            [JsonPropertyName("inicio")]
            public int Inicio { get; set; }

            [JsonPropertyName("parametros")]
            public Parametros Parametros { get; set; }

            [JsonPropertyName("provincias")]
            public List<Provincia> Provincias { get; set; }

            [JsonPropertyName("total")]
            public int Total { get; set; }
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
