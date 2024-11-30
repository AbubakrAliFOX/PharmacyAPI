using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class Supplier
{
    public long Id { get; set; }

    [InverseProperty("Supplier")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    [InverseProperty("Suppliers")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Person Person { get; set; } = null!;
}
