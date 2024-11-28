using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("supplier")]
public partial class Supplier
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("person_id")]
    public long PersonId { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    [ForeignKey("PersonId")]
    [InverseProperty("Suppliers")]
    public virtual Person Person { get; set; } = null!;
}
