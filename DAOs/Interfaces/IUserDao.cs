using InvenProConnect.Models;

namespace InvenProConnect.DAOs.Interfaces
{
    public interface IUserDao : IBaseDao<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync (long id);
        void InsertUser (User user);
        void UpdateUser (User user);
        void DeleteUser(User user);
    }
}
