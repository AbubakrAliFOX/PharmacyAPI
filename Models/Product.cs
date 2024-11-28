using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("product")]
public partial class Product
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("barcode")]
    [StringLength(255)]
    [Unicode(false)]
    public string Barcode { get; set; } = null!;

    [Column("requires_prescription")]
    public bool RequiresPrescription { get; set; }

    [Column("frequency_limit_days")]
    public int? FrequencyLimitDays { get; set; }

    /// <summary>
    /// Takes in an a wysiwyg string
    /// </summary>
    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// 1 = Injection, 2 = Tablet, 3 = Syrup
    /// </summary>
    [Column("form")]
    public int Form { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("category_id")]
    public long CategoryId { get; set; }

    [Column("manufacturer_id")]
    public long ManufacturerId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("ManufacturerId")]
    [InverseProperty("Products")]
    public virtual Manufacturer Manufacturer { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<ProductBatch> ProductBatches { get; set; } = new List<ProductBatch>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
