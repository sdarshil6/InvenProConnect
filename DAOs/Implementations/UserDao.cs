using InvenProConnect.DAOs.Interfaces;
using InvenProConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace InvenProConnect.DAOs.Implementations
{
    public class UserDao : BaseDao<User>, IUserDao
    {
        public UserDao(InventoryManagementSystemContext context) : base(context) 
        {

        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            return await FindByCondition(u => u.UserId == id).FirstOrDefaultAsync();
        }

        public void InsertUser(User user)
        {
            Create(user);
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
