using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class InventoryAdjustment
{
    public int Id { get; set; }

    /// <summary>
    /// 1 = Damage, 2 = Expiration, 3 = Correction, 4 = Theft, 5 = Other
    /// </summary>
    public int Reason { get; set; }

    public string? Description { get; set; }

    public int QuantityChange { get; set; }

    public DateTime Date { get; set; }

    [InverseProperty("InventoryAdjustments")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ProductBatch ProductBatch { get; set; } = null!;

    [InverseProperty("InventoryAdjustments")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual User User { get; set; } = null!;
}
