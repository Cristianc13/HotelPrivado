using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelPrivado.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult Panel()
        {
            return View();
        }

        public IActionResult Panel2()
        {
            return View();
        }
    }
}