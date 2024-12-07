using PharmacyAPI.DTOs;
using PharmacyAPI.Models;

namespace PharmacyAPI.Mapping
{
    public class BranchMapping
    {
        public static BranchBasic ToBranchBasic(Branch branch)
        {
            if (branch is not null)
            {
                return new BranchBasic { Id = branch.Id, Name = branch.Name };
            }
            return null;
        }
    }
}
