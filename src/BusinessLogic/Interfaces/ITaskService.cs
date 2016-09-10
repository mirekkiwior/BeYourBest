using System;
using System.Collections.Generic;
using DAL.Enums;
using DAL.Models;

namespace BusinessLogic.Interfaces
{
    public interface ITaskService
    {
        void AddNewTask(string title, string description, DateTime deadline, TaskTypes type, Goal goal);
        IEnumerable<Quest> GeTasksByGoal(int goalId);
        void UpdateTask(Quest quest);
        void DeleteTask(Quest quest);
    }
}