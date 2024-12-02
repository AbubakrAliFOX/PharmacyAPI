using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Index(nameof(Number), IsUnique = true)]
public partial class Branch
{
    public int Id { get; set; }

    public virtual int Number { get; set; }

    [StringLength(300)]
    public string Description { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    [Precision(9, 6)]
    public decimal Latitude { get; set; }

    [Precision(9, 6)]
    public decimal Longitude { get; set; }

    [InverseProperty("Branch")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    [InverseProperty("Branches")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual User Manager { get; set; } = null!;

    [InverseProperty("Branch")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [InverseProperty("Branch")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
