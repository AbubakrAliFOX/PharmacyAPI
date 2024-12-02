using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Enums;

namespace PharmacyAPI.DTOs.User
{
    public class UserExtensive
    {
        public int Id { get; set; } // Only send the Role ID
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public Gender Gender { get; set; }
        public int? BranchId { get; set; } // Only send the Branch ID
        public int? ManagerId { get; set; } // Only send the Manager ID
        public int RoleId { get; set; } // Only send the Role ID
    }
}
