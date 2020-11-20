using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GUUI2.Controllers
{
    [Authorize(Policy = "Receptionist")]
    public class Receptionist : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
