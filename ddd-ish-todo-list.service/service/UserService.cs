using ddd_ish_todo_list.core.domain.entity;
using ddd_ish_todo_list.core.domain.repository;
using ddd_ish_todo_list.infrastructure;

namespace ddd_ish_todo_list.service.service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(string name)
        {
            return _userRepository.CreateUser(name);
        }

        public User? GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }
        
        public User? GetUserByName(string userName)
        {
            return _userRepository.GetUserByName(userName);
        }
    }
}