using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Enums;
using PharmacyAPI.Models;

namespace PharmacyAPI.DTOs
{
    public class UserMetadata
    {
        public List<RoleBasic> Roles { get; set; }
        public List<BranchBasic> Branches { get; set; }
        public List<ManagerBasic> Managers { get; set; }
    }
}
