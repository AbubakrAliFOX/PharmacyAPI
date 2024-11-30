﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class ProductBatch
{
    public long Id { get; set; }

    public long Quantity { get; set; }

    [Precision(8, 2)]
    public decimal CostPrice { get; set; }

    [Precision(8, 2)]
    public decimal SellingPrice { get; set; }

    public DateOnly ExpirationDate { get; set; }

    [InverseProperty("ProductBatches")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Batch Batch { get; set; } = null!;

    [InverseProperty("ProductBatch")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustments { get; set; } =
        new List<InventoryAdjustment>();

    [InverseProperty("ProductBatches")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Product Product { get; set; } = null!;
}
