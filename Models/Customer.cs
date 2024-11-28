using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("customer")]
public partial class Customer
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("customer_number")]
    public long CustomerNumber { get; set; }

    [Column("is_blocked")]
    public bool IsBlocked { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("Customers")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
