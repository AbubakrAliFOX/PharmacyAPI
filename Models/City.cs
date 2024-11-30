using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
