using PharmacyAPI.DTOs;
using PharmacyAPI.Models;

namespace PharmacyAPI.Mapping
{
    public class RoleMapping
    {
        public static RoleBasic ToRoleBasic(Role role)
        {
            return new RoleBasic { Id = role.Id, Name = role.Name };
        }
    }
}
