using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Table("user")]
[Index("Email", Name = "unique_email", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("is_admin")]
    public bool IsAdmin { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("role_id")]
    public long RoleId { get; set; }

    /// <summary>
    /// If a user has no manager, he is either manager or admin
    /// </summary>
    [Column("manager_id")]
    public long? ManagerId { get; set; }

    /// <summary>
    /// If a user has no branch, he is admin
    /// </summary>
    [Column("branch_id")]
    public long? BranchId { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Users")]
    public virtual Branch? Branch { get; set; }

    [InverseProperty("Manager")]
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    [InverseProperty("User")]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustments { get; set; } = new List<InventoryAdjustment>();

    [InverseProperty("Manager")]
    public virtual ICollection<User> InverseManager { get; set; } = new List<User>();

    [ForeignKey("ManagerId")]
    [InverseProperty("InverseManager")]
    public virtual User? Manager { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("Users")]
    public virtual Person Person { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
