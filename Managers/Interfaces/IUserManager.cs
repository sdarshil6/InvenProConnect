using InvenProConnect.DTOs;
using InvenProConnect.Models;

namespace InvenProConnect.Managers.Interfaces
{
    public interface IUserManager
    {
        Task<List<GetAllUsersDto>> GetAllUsers();
        Task<GetUserDto> GetUserById(long id);
        Task InsertUser(InsertUserDto insertUserDto);
        Task DeleteUser(User user);
        Task UpdateUser(long id, UpdateUserDto updateUserDto);
    }
}
