using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proyecto_test.Models;

namespace proyecto_test.Controllers
{
    public class ClimaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}