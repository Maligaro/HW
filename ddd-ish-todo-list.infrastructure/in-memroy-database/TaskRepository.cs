using System;
using System.Collections.Generic;
using System.Linq;
using ddd_ish_todo_list.core.domain;
using ddd_ish_todo_list.core.domain.entity;
using ddd_ish_todo_list.core.domain.repository;

namespace ddd_ish_todo_list.infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<ToDoTask> _tasks = new List<ToDoTask>();
        
        public TaskRepository() { }

        public ToDoTask CreateTask(string title, string details, int userId)
        {
            var task = new ToDoTask(_tasks.Count, details, title, userId);
            _tasks.Add(task);
            return task;
        }
        
        public ToDoTask? GetTask(int id)
        {
            return _tasks
                .FirstOrDefault(task => task.Id == id);
        }
        
        public ToDoTask[]? GetTasksByUser(int userId)
        {
            return _tasks
                .Where(task => task.OwnerId == userId)
                .OrderBy(task => task.Id)
                .ToArray();
        }

        public ToDoTask? RemoveTask(int id)
        {
            var task = _tasks.FirstOrDefault(taskToRemove => taskToRemove.Id == id);
            if (task != null)
                _tasks.Remove(task);
            return task;
        }
    }
}