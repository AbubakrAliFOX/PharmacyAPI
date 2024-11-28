using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("product_sale")]
public partial class ProductSale
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("sale_id")]
    public long SaleId { get; set; }

    [Column("product_id")]
    public long ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductSales")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("SaleId")]
    [InverseProperty("ProductSales")]
    public virtual Sale Sale { get; set; } = null!;
}
