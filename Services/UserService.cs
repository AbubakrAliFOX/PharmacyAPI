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

        public async Task<UserExtensive> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);

            return UserMapping.ToUserExtensive(user);
        }

        public UserExtensive AddUser(UserCreate userDTO)
        {
            var user = UserMapping.ToUserEntity(userDTO);
            _userRepository.Add(user);
            return UserMapping.ToUserExtensive(user);
        }

        public async Task UpdateUser(UserExtensive userDTO)
        {
            try
            {
                User user = await _userRepository.GetById(userDTO.Id);

                if (user == null)
                    throw new KeyNotFoundException($"User with ID {userDTO.Id} not found.");

                // Update fields
                user.UserName = userDTO.UserName;
                user.Email = userDTO.Email;
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.PhoneNumber = userDTO.PhoneNumber;
                user.Address = userDTO.Address;
                user.Gender = userDTO.Gender;
                user.BranchId = userDTO.BranchId;
                user.ManagerId = userDTO.ManagerId;
                user.RoleId = userDTO.RoleId;

                // Persist changes
                await _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error updating user: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}
