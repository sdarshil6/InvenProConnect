using AutoMapper;
using InvenProConnect.DAOs.Interfaces;
using InvenProConnect.DTOs;
using InvenProConnect.Managers.Interfaces;
using InvenProConnect.Models;
using Serilog;

namespace InvenProConnect.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        private IDaoWrapper _daoWrapper;
        private IMapper _mapper;

        public UserManager(IDaoWrapper daoWrapper, IMapper mapper)
        {
            _daoWrapper = daoWrapper;
            _mapper = mapper;
        }

        public async Task DeleteUser(User user)
        {
            try
            {
                _daoWrapper.UserDao.DeleteUser(user);
                await _daoWrapper.SaveAsync();
                Log.Information("User Deleted.");

            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserManager.cs in DeleteUser() : " + ex.Message, ex);
                throw;
            }
        }

        public async Task<List<GetAllUsersDto>> GetAllUsers()
        {
            try
            {
                IEnumerable<User> userEnumerable = await _daoWrapper.UserDao.GetAllUsersAsync();
                Log.Information("Retrieved all users from the database");
                List<User> userList = userEnumerable.ToList();
                List<GetAllUsersDto> dtoUserList = _mapper.Map<List<GetAllUsersDto>>(userList);
                return dtoUserList;
            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserManager.cs in GetAllUsers() : " + ex.Message, ex);
                throw;
            }
        }

        public async Task<GetUserDto> GetUserById(long id)
        {
            try
            {
                User user = await _daoWrapper.UserDao.GetUserByIdAsync(id);
                Log.Information("Retrieved a user with id " + id + " from the database");
                GetUserDto userDto = _mapper.Map<GetUserDto>(user);
                return userDto;
            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserManager.cs in GetUserById() : " + ex.Message, ex);
                throw;
            }
        }

        public async Task InsertUser(InsertUserDto insertUserDto)
        {
            try
            {
                User user = _mapper.Map<User>(insertUserDto);
                _daoWrapper.UserDao.Create(user);
                await _daoWrapper.SaveAsync();
                Log.Information("User inserted.");
            }
            catch(Exception ex)
            {
                Log.Error("Error occured inside class UserManager.cs in InsertUser() : " + ex.Message, ex);
                throw;
            }
        }

        public async Task UpdateUser(long id, UpdateUserDto updateUserDto)
        {
            try
            {
                User user = await _daoWrapper.UserDao.GetUserByIdAsync(id);
                _mapper.Map(updateUserDto, user);
                _daoWrapper.UserDao.Update(user);
                await _daoWrapper.SaveAsync();
                Log.Information("User updated.");
            }
            catch (Exception ex)
            {
                Log.Error("Error occured inside class UserManager.cs in UpdateUser() : " + ex.Message, ex);
                throw;
            }
        }
    }
}
