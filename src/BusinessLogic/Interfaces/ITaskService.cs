using System;
using System.Collections.Generic;
using DAL.Enums;
using DAL.Models;

namespace BusinessLogic.Interfaces
{
    public interface ITaskService
    {
        void AddNewTask(string title, string description, DateTime deadline, Goal goal, int repeatabilityInDays);
        IEnumerable<Task> GetTasksByGoal(int goalId);
        void UpdateTask(Task task);
        void DeleteTask(Task task);
        void ChangeIsDoneValue(int taskId);
    }
}