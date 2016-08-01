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

        public IEnumerable<Quest> GeTasksByGoal(Goal goal)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                return dbContext.Tasks.Where(t => t.Goal.Id == goal.Id);
            }
        }

        public void UpdateTask(Quest quest)
        {
            InsertOrUpdateTask(quest);
        }

        public void DeleteTask(Quest quest)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                dbContext.Tasks.Remove(quest);
                dbContext.SaveChanges();
            }
        }

        private void InsertOrUpdateTask(Quest quest)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                dbContext.Tasks.Add(quest);
                dbContext.SaveChanges();
            }
        }
    }
}
