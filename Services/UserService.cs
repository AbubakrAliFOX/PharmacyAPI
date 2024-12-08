using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Data.Repositories.Interfaces;
using PharmacyAPI.DTOs;
using PharmacyAPI.DTOs.User;
using PharmacyAPI.Mapping;
using PharmacyAPI.Models;
using PharmacyAPI.Repositories.Interfaces;

namespace PharmacyAPI.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserBasic>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            return users.Select(UserMapping.ToUserBasic).ToList();
        }

        public async Task<UserShow> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user is not null)
            {
                return UserMapping.ToUserShow(user);
            }

            return null;
        }

        public async Task<UserBasic> AddUser(UserCreate userDTO)
        {
            var addedUser = await _userRepository.Add(UserMapping.ToUserEntity(userDTO));
            return UserMapping.ToUserBasic(addedUser);
        }

        public async Task UpdateUser(UserUpdate userDTO)
        {
            try
            {
                User user = await _userRepository.GetById(userDTO.Id);

                if (user == null)
                    throw new KeyNotFoundException($"User with ID {userDTO.Id} not found.");

                user.UserName = userDTO.UserName;
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.PhoneNumber = userDTO.PhoneNumber;
                user.Address = userDTO.Address ?? null;
                user.Gender = userDTO.Gender;
                user.BranchId = userDTO.BranchId;
                user.ManagerId = userDTO.ManagerId;
                user.RoleId = userDTO.RoleId;

                await _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<bool> UserExists(string email)
        {
            var existingUser = await _userRepository.GetByEmail(email.Trim().ToLower());
            if (existingUser != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeactivateUser(int id)
        {
            return await _userRepository.Deactivate(id);
        }

        public async Task<bool> ActivateUser(int id)
        {
            return await _userRepository.Activate(id);
        }
    }
}
