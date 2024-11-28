using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("branch")]
public partial class Branch
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("longitude")]
    [StringLength(15)]
    [Unicode(false)]
    public string Longitude { get; set; } = null!;

    [Column("latitude")]
    [StringLength(15)]
    [Unicode(false)]
    public string Latitude { get; set; } = null!;

    [Column("manager_id")]
    public long ManagerId { get; set; }

    [InverseProperty("Branch")]
    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    [ForeignKey("ManagerId")]
    [InverseProperty("Branches")]
    public virtual User Manager { get; set; } = null!;

    [InverseProperty("Branch")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [InverseProperty("Branch")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
