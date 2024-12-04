using PharmacyAPI.DTOs;
using PharmacyAPI.Models;

namespace PharmacyAPI.Mapping
{
    public class BranchMapping
    {
        public static BranchBasic ToBranchBasic(Branch branch)
        {
            return new BranchBasic { Id = branch.Id, Name = branch.Name };
        }
    }
}
