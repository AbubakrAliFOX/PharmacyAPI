using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("batch")]
public partial class Batch
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("total_cost", TypeName = "decimal(8, 2)")]
    public decimal TotalCost { get; set; }

    [Column("supplier_id")]
    public long SupplierId { get; set; }

    [Column("branch_id")]
    public long BranchId { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Batches")]
    public virtual Branch Branch { get; set; } = null!;

    [InverseProperty("Batch")]
    public virtual ICollection<ProductBatch> ProductBatches { get; set; } = new List<ProductBatch>();

    [ForeignKey("SupplierId")]
    [InverseProperty("Batches")]
    public virtual Supplier Supplier { get; set; } = null!;
}
