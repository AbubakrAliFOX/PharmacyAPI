using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class Customer
{
    public int Id { get; set; }

    public int CustomerNumber { get; set; }

    public bool IsBlocked { get; set; }

    [InverseProperty("Customers")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("Customer")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
