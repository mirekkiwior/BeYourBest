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
        private readonly ApplicationDbContext _dbContext;

        public GoalService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
            return _dbContext.Goals.Where(g => g.Category.Id == category.Id);
        }

        public IEnumerable<Goal> GetGoalsByUser(string userId)
        {
            return _dbContext.Goals.Where(g => g.Category.Owner.Id == userId);
        }

        public void UpdateGoal(Goal goal)
        {
            InsertOrUpdateGoal(goal);
        }

        public void DeleteGoal(Goal goal)
        {
            _dbContext.Goals.Remove(goal);
            _dbContext.SaveChanges();
        }

        private void InsertOrUpdateGoal(Goal goal)
        {
            _dbContext.Goals.Add(goal);
            _dbContext.SaveChanges();
        }
    }
}
