using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using System.Linq;
using DAL.Data;
using DAL.Enums;
using DAL.Models;
using Task = DAL.Models.Task;

namespace BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        public void AddNewTask(string name, string description, DateTime deadline, TaskTypes type, Goal goal)
        {
            Task task = new Task()
            {
                Name = name,
                Description = description,
                Deadline = deadline,
                Type = type,
                Goal = goal
            };

            InsertOrUpdateTask(task);
        }

        public IEnumerable<Task> GeTasksByGoal(Goal goal)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                return dbContext.Tasks.Where(t => t.Goal.Id == goal.Id);
            }
        }

        public void UpdateTask(Task task)
        {
            InsertOrUpdateTask(task);
        }

        public void DeleteTask(Task task)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                dbContext.Tasks.Remove(task);
                dbContext.SaveChanges();
            }
        }

        private void InsertOrUpdateTask(Task task)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                dbContext.Tasks.Add(task);
                dbContext.SaveChanges();
            }
        }
    }
}
