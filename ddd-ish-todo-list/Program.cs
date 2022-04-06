using ddd_ish_todo_list.service.service;
using ddd_ish_todo_list.infrastructure;
using ddd_ish_todo_list.cli;

namespace ddd_ish_todo_list
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var userRep = new UserRepository();
            var taskRep = new TaskRepository();
            
            var userService = new UserService(userRep);
            var todoListService = new TodoListService(taskRep);
            
            var cli = new Cli(todoListService, userService);
            cli.Run();
        }
    }
}