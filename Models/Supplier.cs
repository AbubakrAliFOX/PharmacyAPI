using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

public partial class Supplier
{
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(true)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(true)]
    public string LastName { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [InverseProperty("Supplier")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();
}
