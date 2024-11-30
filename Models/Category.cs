using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
