using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Enums;
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

        public IActionResult LoadCategories()
        {
            return ViewComponent("LeftMenu", new { elementsType = LeftMenuElementsType.Category });
        }

        public IActionResult LoadGoals()
        {
            return ViewComponent("LeftMenu", new { elementsType = LeftMenuElementsType.Goal });
        }
    }
}