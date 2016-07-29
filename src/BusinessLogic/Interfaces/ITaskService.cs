using System;
using System.Collections.Generic;
using DAL.Enums;
using DAL.Models;
using Task = DAL.Models.Task;

namespace BusinessLogic.Interfaces
{
    public interface ITaskService
    {
        void AddNewTask(string title, string description, DateTime deadline, TaskTypes type, Goal goal);
        IEnumerable<Task> GeTasksByGoal(Goal goal);
        void UpdateTask(Task task);
        void DeleteTask(Task task);
    }
}