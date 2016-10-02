using System.Collections.Generic;
using BeYourBest.Models.MainViewModels;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeYourBest.ViewComponents
{
    public class TasksListViewComponent : ViewComponent
    {
        private readonly ITaskService _taskService;

        public TasksListViewComponent(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IViewComponentResult Invoke(int goalId)
        {
            var tasks = GetTasks(goalId);
            return View(tasks);
        }

        private List<TasksListViewModel> GetTasks(int goalId)
        {
            var result = new List<TasksListViewModel>();

            foreach (var task in _taskService.GetTasksByGoal(goalId))
            {
                result.Add(new TasksListViewModel()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Deadline = task.Deadline,
                    Description = task.Description,
                    IsDone = task.IsDone
                });
            }
            return result;
        }
    }
}
