using System.Runtime.CompilerServices;

namespace ddd_ish_todo_list.core.domain.entity
{
    public class User
    {
        public string Name { get; }
        public int Id { get; }
        
        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}