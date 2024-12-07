using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.DTOs;
using PharmacyAPI.Enums;

namespace PharmacyAPI.Models;

[Index(nameof(Email), IsUnique = true)]
public partial class User
{
    public int Id { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    public string? ImageUrl { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(true)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(true)]
    public string LastName { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Unicode(true)]
    public string? Address { get; set; }

    public Gender Gender { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsDeleted { get; set; } = false;

    public int? ManagerId { get; set; }
    public int? BranchId { get; set; }
    public int RoleId { get; set; }

    /// <summary>
    /// If a user has no branch, he is admin
    /// </summary>
    [ForeignKey(nameof(BranchId))]
    [InverseProperty("Users")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual Branch? Branch { get; set; }

    /// <summary>
    /// If a user has no manager, he is either manager or admin
    /// </summary>
    [InverseProperty("Manager")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    [InverseProperty("User")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<InventoryAdjustment> InventoryAdjustments { get; set; } =
        new List<InventoryAdjustment>();

    [InverseProperty("Manager")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<User> InverseManager { get; set; } = new List<User>();

    [ForeignKey(nameof(ManagerId))]
    [InverseProperty("InverseManager")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual User? Manager { get; set; }

    [ForeignKey(nameof(RoleId))]
    [InverseProperty("Users")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
