using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ddd_ish_todo_list.core.domain.entity;
using ddd_ish_todo_list.service.service;

namespace ddd_ish_todo_list.cli
{
    public class Cli
    {
        private TodoListService _todoListService;
        private UserService _userService;
        private User? _user = null;
        private ToDoTask[]? _tasks = null;
        private Dictionary<string, Command> _commands;
        private bool _exit = false;

        public Cli(TodoListService todoListService, UserService userService)
        {
            _todoListService = todoListService;
            _userService = userService;

            _commands = new Dictionary<string, Command> 
            {
                {"login", new Command(Login, "login <username> #no spaces in username") },
                {"register", new Command(Register, "register <username> #no spaces in username") },
                {"logout", new Command(Logout, "logout") },
                
                {"list", new Command(List, "list") },
                {"task", new Command(Task, "task <index>") },
                {"create", new Command(Create, "create") },
                {"remove", new Command(Remove, "remove <index>") },
                {"exit", new Command(Exit, "exit") },
                {"help", new Command(Help, "help") },
            };
        }

        public void Run()
        {
            Console.WriteLine("start...");
            while (true)
            {
                if (_exit)
                {
                    Console.WriteLine("exit...");
                    return;
                }
                
                var input = Console.ReadLine()
                    .Trim()
                    .Split()
                    .ToList();
                
                if (input.Count > 0 && _commands.ContainsKey(input[0].ToLowerInvariant()))
                {
                    try
                    {
                        _commands[input[0].ToLowerInvariant()].Action.Invoke(input);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        private void Exit(List<string> input)
        {
            _exit = true;
        }
        
        private void Help(List<string> input)
        {
            if (input.Count != 1) throw new ArgumentException();
            Console.WriteLine("Available commands:");
            foreach (var command in _commands)
                Console.WriteLine( command.Value.Description);
            Console.WriteLine();
        }
        
        private void Register(List<string> input)
        {
            if (input.Count != 2 || input[1].Contains(' ')) throw new ArgumentException();
            var username = input[1];
            _user = _userService.CreateUser(username);
            Console.WriteLine("User created");
        }
        
        private void Login(List<string> input)
        {
            if (input.Count != 2 || input[1].Contains(' ')) throw new ArgumentException();
            
            var username = input[1];
            _user = _userService.GetUserByName(username);
            Console.WriteLine("Logged in as " + _user.Name);
        }
        
        private void Logout(List<string> input)
        {
            if (input.Count != 1) throw new ArgumentException();
            _user = null;
            Console.WriteLine("Logout ((");
        }

        private void List(List<string> input)
        {
            if (_user is null)
            {
                Console.WriteLine("You ned to login to run this command");
                return;
            }

            Console.WriteLine("Task list:");
            _tasks = _todoListService.GetTasksByUser(_user.Id);
            for (var i = 0; i < _tasks.Length; i++)
                Console.WriteLine(i + " : " + _tasks[i].Title);
            Console.WriteLine();
        }

        private void Task(List<string> input)
        {
            int index;
            if (input.Count != 2 || _user is null || !int.TryParse(input[1], out index))
                throw new ArgumentException();

            _tasks = _todoListService.GetTasksByUser(_user.Id);
            var task = _todoListService.GetTask(_tasks[index].Id);
            Console.WriteLine("Task №" + index);
            Console.WriteLine("\t Title : " + task.Title);
            Console.WriteLine("\t Details : " + task.Details);
            Console.WriteLine();
        }

        private void Create(List<string> input)
        {
            if (_user is null)
                throw new ArgumentException();
            
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Details: ");
            var details = Console.ReadLine();
            _todoListService.CreateTask(title, details, _user.Id);
            Console.WriteLine("Task created");
        }

        private void Remove(List<string> input)
        {
            int index;
            if (input.Count != 2 || _user is null || !int.TryParse(input[1], out index))
                throw new ArgumentException();

            _tasks = _todoListService.GetTasksByUser(_user.Id);
            _todoListService.RemoveTask(_tasks[index].Id);
            Console.WriteLine("Task removed");
        }
    }
}