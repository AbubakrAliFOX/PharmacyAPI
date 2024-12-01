using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Barcode { get; set; } = null!;

    public bool RequiresPrescription { get; set; }

    public int? FrequencyLimitDays { get; set; }

    /// <summary>
    /// Takes in an a wysiwyg string
    /// </summary>
    [Column(TypeName = "text")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// 1 = Injection, 2 = Tablet, 3 = Syrup
    /// </summary>
    public int Form { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Products")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Products")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Manufacturer Manufacturer { get; set; } = null!;

    [InverseProperty("Product")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<ProductBatch> ProductBatches { get; set; } =
        new List<ProductBatch>();

    [InverseProperty("Product")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
