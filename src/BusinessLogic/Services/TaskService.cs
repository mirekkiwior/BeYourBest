using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using System.Linq;
using DAL.Data;
using DAL.Enums;
using DAL.Models;

namespace BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNewTask(string name, string description, DateTime deadline, TaskTypes type, Goal goal)
        {
            Quest quest = new Quest()
            {
                Name = name,
                Description = description,
                Deadline = deadline,
                Type = type,
                Goal = goal
            };

            InsertOrUpdateTask(quest);
        }

        public IEnumerable<Quest> GeTasksByGoal(int goalId)
        {
            return _dbContext.Tasks.Where(t => t.Goal.Id == goalId);
        }

        public void UpdateTask(Quest quest)
        {
            InsertOrUpdateTask(quest);
        }

        public void DeleteTask(Quest quest)
        {
            _dbContext.Tasks.Remove(quest);
            _dbContext.SaveChanges();
        }

        private void InsertOrUpdateTask(Quest quest)
        {
            _dbContext.Tasks.Add(quest);
            _dbContext.SaveChanges();
        }
    }
}
