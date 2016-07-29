using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using DAL.Data;
using DAL.Models;

namespace BusinessLogic.Services
{
    public class GoalService : IGoalService
    {
        public void AddNewGoal(string title, string description, DateTime deadline, Category category)
        {
            Goal goal = new Goal()
            {
                Title = title,
                Description = description,
                Deadline = deadline,
                Category = category
            };
            InsertOrUpdateGoal(goal);
        }

        public IEnumerable<Goal> GetGoalsByCategory(Category category)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                return dbContext.Goals.Where(g => g.Category.Id == category.Id);
            }
        }

        public void UpdateGoal(Goal goal)
        {
            InsertOrUpdateGoal(goal);
        }

        public void DeleteGoal(Goal goal)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                dbContext.Goals.Remove(goal);
                dbContext.SaveChanges();
            }
        }

        private void InsertOrUpdateGoal(Goal goal)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                dbContext.Goals.Add(goal);
                dbContext.SaveChanges();
            }
        }
    }
}
