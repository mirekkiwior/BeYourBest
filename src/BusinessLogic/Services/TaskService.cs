using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using System.Linq;
using DAL.Data;
using DAL.Enums;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNewTask(string name, string description, DateTime deadline, Goal goal, int repeatabilityInDays)
        {
            Task task = new Task()
            {
                Name = name,
                Description = description,
                Deadline = deadline,
                Goal = goal,
                IsDone = false,
                IsImportant = false,
                RepeatabilityInDays = repeatabilityInDays
            };

            InsertOrUpdateTask(task);
        }

        public IEnumerable<Task> GetTasksByGoal(int goalId)
        {
            return _dbContext.Tasks.Where(t => t.Goal.Id == goalId);
        }

        public void UpdateTask(Task task)
        {
            InsertOrUpdateTask(task);
        }

        public void DeleteTask(Task task)
        {
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }

        public void ChangeIsDoneValue(int taskId)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return;
            task.IsDone = !task.IsDone;
            InsertOrUpdateTask(task);
        }

        private void InsertOrUpdateTask(Task task)
        {
            if (task.Id == default(int))
                _dbContext.Tasks.Add(task);
            else
            {
                _dbContext.Entry(task).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }
    }
}
