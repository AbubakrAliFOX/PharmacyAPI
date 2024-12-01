using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.DTOs;
using PharmacyAPI.DTOs.User;
using PharmacyAPI.Models;

namespace PharmacyAPI.Mapping
{
    public class UserMapping
    {
        public static UserBasic ToUserBasic(User user)
        {
            return new UserBasic
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                BranchId = user.BranchId,
                ManagerId = user.ManagerId,
                RoleId = user.RoleId
            };
        }

        public static User ToUserEntity(UserBasic userBasicDTO)
        {
            return new User
            {
                Id = userBasicDTO.Id,
                // PersonId = userBasicDTO.PersonId,
                UserName = userBasicDTO.UserName,
                Email = userBasicDTO.Email,
                BranchId = userBasicDTO.BranchId,
                ManagerId = userBasicDTO.ManagerId,
                RoleId = userBasicDTO.RoleId
            };
        }

        public static User ToUserEntity(UserDTOExtensive userDTOEx)
        {
            return new User
            {
                Id = userDTOEx.Id,
                PersonId = userDTOEx.PersonId,
                UserName = userDTOEx.UserName,
                Password = userDTOEx.Password,
                PasswordSalt = userDTOEx.PasswordSalt,
                Email = userDTOEx.Email,
                BranchId = userDTOEx.BranchId,
                ManagerId = userDTOEx.ManagerId,
                RoleId = userDTOEx.RoleId
            };
        }

        public static UserWithPerson ToUserWithPerson(User user, Person person)
        {
            PersonBasic personBasic = PersonMapping.ToPersonBasic(person);
            UserBasic userBasic = ToUserBasic(user);
            return new UserWithPerson { personBasicInfo = personBasic, userBasicInfo = userBasic };
        }
    }
}
