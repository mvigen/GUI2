using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GUUI2.Controllers
{
    [Authorize(Policy = "Tjener")]
    public class Tjener : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
