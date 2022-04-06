using ddd_ish_todo_list.core.domain.entity;

namespace ddd_ish_todo_list.core.domain.repository
{
    public interface ITaskRepository
    {
        public ToDoTask CreateTask(string title, string details, int userId);
        public ToDoTask[]? GetTasksByUser(int userId);
        public ToDoTask? GetTask(int id);
        public ToDoTask? RemoveTask(int id);
        
    }
}