using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Enums;

namespace PharmacyAPI.Models;

public partial class Person
{
    public long Id { get; set; }

    [StringLength(50)]
    [Unicode(true)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(true)]
    public string LastName { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(255)]
    [Unicode(true)]
    public string? Address { get; set; }

    public Gender Gender { get; set; }

    [InverseProperty("Person")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("Person")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    [InverseProperty("Person")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
