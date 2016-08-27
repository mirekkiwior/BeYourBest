using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeYourBest.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
    }
}