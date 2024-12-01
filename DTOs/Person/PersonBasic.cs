using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Enums;
using PharmacyAPI.Models;

namespace PharmacyAPI.DTOs
{
    public class PersonBasic
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public Gender Gender { get; set; }
    }
}
