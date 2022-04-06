using System.Collections.Generic;
using System.Linq;
using ddd_ish_todo_list.core.domain;
using ddd_ish_todo_list.core.domain.entity;
using ddd_ish_todo_list.core.domain.repository;

namespace ddd_ish_todo_list.infrastructure
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();
        
        public UserRepository(){}
        
        public User? GetUser(int id)
        {
            return _users
                .FirstOrDefault(user => user.Id == id);
        }
        
        public User? GetUserByName(string name)
        {
            return _users
                .FirstOrDefault(user => user.Name.Equals(name));
        }

        public User CreateUser(string name)
        {
            var user = new User(_users.Count, name);
            _users.Add(user);
            return user;
        }
    }
}