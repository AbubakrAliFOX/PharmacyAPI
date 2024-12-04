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
                FullName = user.FirstName + " " + user.LastName,
                BranchName = user.Branch?.Name,
                RoleName = user.Role?.Name,
            };
        }

        public static UserExtensive ToUserExtensive(User user)
        {
            return new UserExtensive
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Gender = user.Gender,
                Email = user.Email,
                BranchId = user.BranchId,
                ManagerId = user.ManagerId,
                RoleId = user.RoleId
            };
        }

        public static UserCreate ToUserCreate(User user)
        {
            return new UserCreate
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Gender = user.Gender,
                Password = user.Password,
                PasswordSalt = user.PasswordSalt,
                BranchId = user.BranchId,
                ManagerId = user.ManagerId,
                RoleId = user.RoleId
            };
        }

        // public static User ToUserEntity(UserBasic userBasicDTO)
        // {
        //     return new User
        //     {
        //         Id = userBasicDTO.Id,
        //         // PersonId = userBasicDTO.PersonId,
        //         UserName = userBasicDTO.UserName,
        //         Email = userBasicDTO.Email,
        //         BranchId = userBasicDTO.BranchId,
        //         ManagerId = userBasicDTO.ManagerId,
        //         RoleId = userBasicDTO.RoleId
        //     };
        // }

        public static User ToUserEntity(UserCreate userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                PhoneNumber = userDTO.PhoneNumber,
                Address = userDTO.Address,
                Gender = userDTO.Gender,
                Password = userDTO.Password,
                PasswordSalt = userDTO.PasswordSalt,
                BranchId = userDTO.BranchId,
                ManagerId = userDTO.ManagerId,
                RoleId = userDTO.RoleId
            };
        }

        public static User ToUserEntity(UserExtensive userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                PhoneNumber = userDTO.PhoneNumber,
                Address = userDTO.Address,
                Gender = userDTO.Gender,
                Email = userDTO.Email,
                BranchId = userDTO.BranchId,
                ManagerId = userDTO.ManagerId,
                RoleId = userDTO.RoleId
            };
        }

        public static ManagerBasic ToManagerBasic(User user)
        {
            return new ManagerBasic
            {
                Id = user.Id,
                FullName = user.FirstName + " " + user.LastName,
                ImageUrl = user.ImageUrl,
                Branch = new BranchBasic { Id = user.Branch.Id, Name = user.Branch.Name }
            };
        }
    }
}
