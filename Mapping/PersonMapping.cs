using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.DTOs;
using PharmacyAPI.Models;

namespace PharmacyAPI.Mapping
{
    public class PersonMapping
    {
        public static PersonBasic ToPersonBasic(Person person)
        {
            return new PersonBasic
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                Gender = person.Gender
            };
        }
    }
}
