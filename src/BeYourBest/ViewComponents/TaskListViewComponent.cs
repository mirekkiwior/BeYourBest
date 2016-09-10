using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeYourBest.ViewComponents
{
    public class TaskListViewComponent : ViewComponent
    {
        private readonly ITaskService _taskService;

        public TaskListViewComponent(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IViewComponentResult Invoke(int goalId)
        {
            var tasks = GetTasks(goalId);
            return View(tasks);
        }

        private List<Quest> GetTasks(int goalId)
        {
            return _taskService.GeTasksByGoal(goalId).ToList();
        }
    }
}
