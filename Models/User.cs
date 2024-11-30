using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Models;

[Index(nameof(Email), IsUnique = true)]
public partial class User
{
    public long Id { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// If a user has no branch, he is admin
    /// </summary>
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

    [InverseProperty("InverseManager")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual User? Manager { get; set; }

    [InverseProperty("Users")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("Users")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
