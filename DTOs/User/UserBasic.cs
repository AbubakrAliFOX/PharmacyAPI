using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Models;

namespace PharmacyAPI.DTOs
{
    public class UserBasic
    {
        public int Id { get; set; }

        // public int PersonId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? BranchId { get; set; }
        public int? ManagerId { get; set; }
        public int RoleId { get; set; }
    }
}
