using ddd_ish_todo_list.core.domain.entity;

namespace ddd_ish_todo_list.core.domain.repository
{
    public interface IUserRepository
    {
        public User? GetUser(int id);
        public User CreateUser(string name);
        public User? GetUserByName(string name);
    }
}