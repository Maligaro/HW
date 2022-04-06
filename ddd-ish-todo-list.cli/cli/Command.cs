using System;
using System.Collections.Generic;

namespace ddd_ish_todo_list.cli
{
    public class Command
    {
        public Action<List<string>> Action;
        public string Description;

        public Command(Action<List<string>> action, string description)
        {
            Action = action;
            Description = description;
        }
    }
}