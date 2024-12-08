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
        public string FullName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
