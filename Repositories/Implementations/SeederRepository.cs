using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data.Repositories.Interfaces;
using PharmacyAPI.Enums;
using PharmacyAPI.Models;

namespace PharmacyAPI.Data.Repositories
{
    public class SeederRepository : ISeederRepository
    {
        private readonly DataContext _context;

        public SeederRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Manager" },
                new Role { Name = "Pharmacist" }
            };

            var city1 = new City { Name = "Riyadh" };
            var city2 = new City { Name = "Kharj" };
            var city3 = new City { Name = "Dammam" };
            var city4 = new City { Name = "Jeddah" };

            var adminAndManagers = new List<User>
            {
                new User
                {
                    Email = "user1@example.com",
                    Password = "fasdfasdfadffsd",
                    IsAdmin = true,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Address = "123 Elm Street",
                    Gender = Gender.Male,
                    Role = roles[0],
                    Manager = null,
                    ImageUrl = "https://img.daisyui.com/images/profile/demo/2@94.webp",
                    UserName = "UserOne",
                },
                new User
                {
                    Email = "user2@example.com",
                    Password = "fasdfasdfadffsd",
                    FirstName = "Jane",
                    LastName = "Smith",
                    PhoneNumber = "9876543210",
                    Address = "456 Oak Avenue",
                    Gender = Gender.Female,
                    Role = roles[1],
                    Manager = null,
                    Branch = null,
                    ImageUrl = "https://img.daisyui.com/images/profile/demo/2@94.webp",
                    UserName = "UserTwo",
                },
                new User
                {
                    Email = "user3@example.com",
                    Password = "fasdfasdfadffsd",
                    FirstName = "Michael",
                    LastName = "Johnson",
                    PhoneNumber = "1112223333",
                    Address = "789 Pine Lane",
                    Gender = Gender.Male,
                    Role = roles[1],
                    ManagerId = null,
                    Branch = null,
                    ImageUrl = "https://img.daisyui.com/images/profile/demo/2@94.webp",
                    UserName = "UserThree",
                },
                new User
                {
                    Email = "user4@example.com",
                    Password = "fasdfasdfadffsd",
                    FirstName = "Emily",
                    LastName = "Davis",
                    PhoneNumber = "4445556666",
                    Address = "321 Maple Road",
                    Gender = Gender.Female,
                    Role = roles[2],
                    ManagerId = null,
                    Branch = null,
                    ImageUrl = "https://img.daisyui.com/images/profile/demo/2@94.webp",
                    UserName = "UserFour",
                },
                new User
                {
                    Email = "user5@example.com",
                    Password = "fasdfasdfadffsd",
                    FirstName = "Jack",
                    LastName = "Jones",
                    PhoneNumber = "4445556666",
                    Address = "321 Maple Road",
                    Gender = Gender.Male,
                    Role = roles[2],
                    ManagerId = null,
                    Branch = null,
                    ImageUrl = "https://img.daisyui.com/images/profile/demo/2@94.webp",
                    UserName = "UserFour",
                },
                new User
                {
                    Email = "user6@example.com",
                    Password = "fasdfasdfadffsd",
                    FirstName = "Khaled",
                    LastName = "Ahmad",
                    PhoneNumber = "4445556666",
                    Address = "321 Maple Road",
                    Gender = Gender.Male,
                    Role = roles[2],
                    ManagerId = null,
                    Branch = null,
                    ImageUrl = "https://img.daisyui.com/images/profile/demo/2@94.webp",
                    UserName = "UserSix",
                },
                new User
                {
                    Email = "user7@example.com",
                    Password = "fasdfasdfadffsd",
                    FirstName = "Jane",
                    LastName = "Jones",
                    PhoneNumber = "4445556666",
                    Address = "321 Maple Road",
                    Gender = Gender.Female,
                    Role = roles[2],
                    ManagerId = null,
                    Branch = null,
                    ImageUrl = "https://img.daisyui.com/images/profile/demo/2@94.webp",
                    UserName = "UserSeven",
                }
            };

            List<Branch> branches = new List<Branch>
            {
                new Branch
                {
                    Number = 1,
                    Name = "Al Khaleej",
                    Description =
                        "Al Khaleej District, Kind Abdullah Rd, In Front of Jareer Library",
                    Latitude = 24.789847m,
                    Longitude = 46.807607m,
                    Manager = adminAndManagers[1],
                    City = city1
                },
                new Branch
                {
                    Number = 2,
                    Name = "Al Malaz",
                    Description =
                        "Al Malaz District, Salah Ad Din Al Ayyubi Rd, In Front of Security Forces Hospital",
                    Latitude = 24.789847m,
                    Longitude = 46.807607m,
                    Manager = adminAndManagers[2],
                    City = city2
                },
                new Branch
                {
                    Number = 3,
                    Name = "King Faisal",
                    Description =
                        "King Faisal District, Qis Bin Saeda St, In Front of Al-Jenan Supermarket",
                    Latitude = 24.789847m,
                    Longitude = 46.807607m,
                    Manager = adminAndManagers[3],
                    City = city3
                }
            };

            // adminAndManagers[1].Branch = branches[0];
            // adminAndManagers[2].Branch = branches[1];
            // adminAndManagers[3].Branch = branches[2];

            _context.Cities.AddRange(city1, city2, city3, city4);
            _context.Roles.AddRange(roles);

            _context.Branches.AddRange(branches);
            _context.Users.AddRange(adminAndManagers);

            // Save changes to the database
            _context.SaveChanges();
        }

        public async Task BindUsersWithBranchesAndManagers()
        {
            var users = await _context.Users.Include(user => user.Role).ToListAsync();
            var manager = await _context
                .Users.Include(user => user.Role)
                .Where(user => user.Role.Name == "Manager")
                .FirstOrDefaultAsync();

            foreach (var user in users)
            {
                user.BranchId = 1;
            }

            foreach (var user in users)
            {
                if (user.Role.Name != "Manager")
                    user.ManagerId = manager.Id;
            }

            await _context.SaveChangesAsync();
        }
    }
}
