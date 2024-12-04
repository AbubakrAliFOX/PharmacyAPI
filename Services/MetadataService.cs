using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.DTOs;
using PharmacyAPI.Mapping;
using PharmacyAPI.Repositories.Interfaces;

namespace PharmacyAPI.Services
{
    public class MetadataService
    {
        private readonly IMetadataRepository _metaDataRepository;

        public MetadataService(IMetadataRepository metaDataRepository)
        {
            _metaDataRepository = metaDataRepository;
        }

        public async Task<UserMetadata> GetUserMetadata()
        {
            var roles = await _metaDataRepository.GetRoles();
            var branches = await _metaDataRepository.GetBranches();
            var managers = await _metaDataRepository.GetManagers();
            return new UserMetadata
            {
                Roles = roles.Select(RoleMapping.ToRoleBasic).ToList(),
                Branches = branches.Select(BranchMapping.ToBranchBasic).ToList(),
                Managers = managers.Select(UserMapping.ToManagerBasic).ToList()
            };
        }
    }
}
