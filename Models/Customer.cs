using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Enums;

namespace PharmacyAPI.Models;

public partial class Customer
{
    public int Id { get; set; }

    public int CustomerNumber { get; set; }

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

    public bool IsBlocked { get; set; }

    [InverseProperty("Customer")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
