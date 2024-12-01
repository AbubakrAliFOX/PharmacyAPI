using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.DTOs.User
{
    public class UserWithPerson
    {
        public UserBasic userBasicInfo { get; set; }
        public PersonBasic personBasicInfo { get; set; }
    }
}
