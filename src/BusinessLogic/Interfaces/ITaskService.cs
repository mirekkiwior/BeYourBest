using System;
using System.Collections.Generic;
using DAL.Enums;
using DAL.Models;

namespace BusinessLogic.Interfaces
{
    public interface ITaskService
    {
        void AddNewTask(string title, string description, DateTime deadline, TaskTypes type, Goal goal);
        IEnumerable<Quest> GeTasksByGoal(Goal goal);
        void UpdateTask(Quest quest);
        void DeleteTask(Quest quest);
    }
}