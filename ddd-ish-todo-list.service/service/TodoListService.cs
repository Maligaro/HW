using ddd_ish_todo_list.core.domain.entity;
using ddd_ish_todo_list.core.domain.repository;
using ddd_ish_todo_list.infrastructure;

namespace ddd_ish_todo_list.service.service
{
    public class TodoListService
    {
        private readonly ITaskRepository _taskRepository;

        public TodoListService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        
        public ToDoTask CreateTask(string title, string details, int userId)
        {
            return _taskRepository.CreateTask(title, details, userId);
        }
        
        public ToDoTask? GetTask(int id)
        {
            return _taskRepository.GetTask(id);
        }
        
        public ToDoTask[]? GetTasksByUser(int userId)
        {
            return _taskRepository.GetTasksByUser(userId);
        }

        public ToDoTask? RemoveTask(int id)
        {
           return _taskRepository.RemoveTask(id);
        }
    }
}