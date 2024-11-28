using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("sale")]
public partial class Sale
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("customer_id")]
    public long CustomerId { get; set; }

    [Column("branch_id")]
    public long BranchId { get; set; }

    [Column("total_price", TypeName = "decimal(8, 2)")]
    public decimal TotalPrice { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Sales")]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Sales")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Sale")]
    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    [ForeignKey("UserId")]
    [InverseProperty("Sales")]
    public virtual User User { get; set; } = null!;
}
