using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class ProductSale
{
    public int Id { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [InverseProperty("ProductSales")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Product Product { get; set; } = null!;

    [InverseProperty("ProductSales")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Sale Sale { get; set; } = null!;
}
