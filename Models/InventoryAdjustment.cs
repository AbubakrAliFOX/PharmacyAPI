using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("inventory_adjustment")]
public partial class InventoryAdjustment
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    /// <summary>
    /// 1 = Damage, 2 = Expiration, 3 = Correction, 4 = Theft, 5 = Other
    /// </summary>
    [Column("reason")]
    public int Reason { get; set; }

    [Column("description")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("quantity_change")]
    public int QuantityChange { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("product_batch_id")]
    public long ProductBatchId { get; set; }

    [ForeignKey("ProductBatchId")]
    [InverseProperty("InventoryAdjustments")]
    public virtual ProductBatch ProductBatch { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("InventoryAdjustments")]
    public virtual User User { get; set; } = null!;
}
