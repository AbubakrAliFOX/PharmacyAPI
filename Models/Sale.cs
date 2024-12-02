using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class Sale
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    [Precision(8, 2)]
    public decimal TotalPrice { get; set; }

    [InverseProperty("Sales")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual Branch Branch { get; set; } = null!;

    [InverseProperty("Sales")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Sale")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    [InverseProperty("Sales")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual User User { get; set; } = null!;
}
