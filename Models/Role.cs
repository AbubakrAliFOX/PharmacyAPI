using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("role")]
public partial class Role
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("role")]
    [StringLength(15)]
    [Unicode(false)]
    public string Role1 { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
