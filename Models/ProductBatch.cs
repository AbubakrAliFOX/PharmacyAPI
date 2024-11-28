using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("product_batch")]
public partial class ProductBatch
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("product_id")]
    public long ProductId { get; set; }

    [Column("batch_id")]
    public long BatchId { get; set; }

    [Column("quantity")]
    public long Quantity { get; set; }

    [Column("cost_price", TypeName = "decimal(8, 2)")]
    public decimal CostPrice { get; set; }

    [Column("selling_price", TypeName = "decimal(8, 2)")]
    public decimal SellingPrice { get; set; }

    [Column("expiration_date")]
    public DateOnly ExpirationDate { get; set; }

    [ForeignKey("BatchId")]
    [InverseProperty("ProductBatches")]
    public virtual Batch Batch { get; set; } = null!;

    [InverseProperty("ProductBatch")]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustments { get; set; } = new List<InventoryAdjustment>();

    [ForeignKey("ProductId")]
    [InverseProperty("ProductBatches")]
    public virtual Product Product { get; set; } = null!;
}
