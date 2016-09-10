using System;
using System.Collections.Generic;
using DAL.Models;

namespace BusinessLogic.Interfaces
{
    public interface IGoalService
    {
        void AddNewGoal(string title, string description, DateTime deadline, Category category);
        IEnumerable<Goal> GetGoalsByCategory(Category category);
        IEnumerable<Goal> GetGoalsByUser(string userId);
        void UpdateGoal(Goal goal);
        void DeleteGoal(Goal goal);
    }
}
