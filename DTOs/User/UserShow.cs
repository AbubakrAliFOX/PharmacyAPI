using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Enums;

namespace PharmacyAPI.DTOs.User
{
    public class UserShow
    {
        public int Id { get; set; } // Only send the Role ID
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public string Gender { get; set; }
        public ManagerBasic? Manager { get; set; }
        public RoleBasic Role { get; set; }
        public BranchBasic Branch { get; set; }
    }
}
