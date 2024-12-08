using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Enums;

namespace PharmacyAPI.DTOs.User
{
    public class UserUpdate
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public Gender Gender { get; set; }
        public int? ManagerId { get; set; }
        public int RoleId { get; set; }
        public int BranchId { get; set; }
    }
}
