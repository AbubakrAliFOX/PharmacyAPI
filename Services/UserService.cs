using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Data.Repositories.Interfaces;
using PharmacyAPI.DTOs;
using PharmacyAPI.DTOs.User;
using PharmacyAPI.Mapping;
using PharmacyAPI.Models;

namespace PharmacyAPI.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Person> _personRepository;

        public UserService(IRepository<User> userRepository, IRepository<Person> personRepository)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<UserBasic>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            return users.Select(UserMapping.ToUserBasic).ToList();
        }

        public async Task<UserWithPerson> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            var person = await _personRepository.GetById(user.PersonId);

            return UserMapping.ToUserWithPerson(user, person);
        }

        public void AddUser(UserDTOExtensive userDTO)
        {
            var user = UserMapping.ToUserEntity(userDTO);
            _userRepository.Add(user);
        }

        public void UpdateUser(UserBasic userDTO)
        {
            var user = UserMapping.ToUserEntity(userDTO);
            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
