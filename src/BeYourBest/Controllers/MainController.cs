using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeYourBest.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly ITaskService _taskService;

        public MainController(ITaskService taskService)
        {
            _taskService = taskService;
        }

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

        public IActionResult LoadTasks(int goalId)
        {
            return ViewComponent("TasksList", new { goalId = goalId });
        }

        public void ChangeIsDoneValue(int taskId)
        {
            _taskService.ChangeIsDoneValue(taskId);
        }
    }
}