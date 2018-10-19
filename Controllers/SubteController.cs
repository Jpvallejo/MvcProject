using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proyecto_test.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace proyecto_test.Controllers
{
    public class SubteController : Controller
    {
        private const string apiURL = "https://haysubte.now.sh/api";

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> ObtenerEstadoSubte()
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);

                client.DefaultRequestHeaders.Accept.Clear();
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json") );

                HttpResponseMessage response = await client.GetAsync(apiURL);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var estadoSubtes = JsonConvert.DeserializeObject(data);

                    return Json(estadoSubtes);
                }
            }

            return StatusCode(400);

        }

    }
}
