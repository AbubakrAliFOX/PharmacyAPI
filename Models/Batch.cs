using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class Batch
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    [Precision(8, 2)]
    public decimal TotalCost { get; set; }

    [InverseProperty("Batches")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Branch Branch { get; set; } = null!;

    [InverseProperty("Batch")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<ProductBatch> ProductBatches { get; set; } =
        new List<ProductBatch>();

    [InverseProperty("Batches")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Supplier Supplier { get; set; } = null!;
}
