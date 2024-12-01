using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.DTOs;

namespace PharmacyAPI.Models;

[Index(nameof(Email), IsUnique = true)]
public partial class User
{
    public int Id { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public bool IsDeleted { get; set; } = false;

    public int PersonId { get; set; }
    public int? ManagerId { get; set; }
    public int? BranchId { get; set; }
    public int RoleId { get; set; }

    /// <summary>
    /// If a user has no branch, he is admin
    /// </summary>
    [ForeignKey(nameof(BranchId))]
    [InverseProperty("Users")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Branch? Branch { get; set; }

    /// <summary>
    /// If a user has no manager, he is either manager or admin
    /// </summary>
    [InverseProperty("Manager")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    [InverseProperty("User")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustments { get; set; } =
        new List<InventoryAdjustment>();

    [InverseProperty("Manager")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<User> InverseManager { get; set; } = new List<User>();

    [ForeignKey(nameof(ManagerId))]
    [InverseProperty("InverseManager")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual User? Manager { get; set; }

    [ForeignKey(nameof(PersonId))]
    [InverseProperty("Users")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Person Person { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    [InverseProperty("Users")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
