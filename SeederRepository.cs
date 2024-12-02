using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void Seed()
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
                    Branch = null,
                    PasswordSalt = "fdsfasddf",
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
                    PasswordSalt = "fdsfasddf",
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
                    Manager = null,
                    Branch = null,
                    PasswordSalt = "fdsfasddf",
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
                    Role = roles[1],
                    Manager = null,
                    Branch = null,
                    PasswordSalt = "fdsfasddf",
                    UserName = "UserFour",
                }
            };

            // var users = new List<User>
            // {
            //     new User
            //     {
            //         Email = "user5@example.com",
            //         Password = "fasdfasdfadffsd",
            //         Person = persons[0],
            //         Role = roles[2],
            //         Manager = null,
            //         Branch = null,
            //         PasswordSalt = "fdsfasddf",
            //         UserName = "UserFive",
            //     },
            //     new User
            //     {
            //         Email = "user2@example.com",
            //         Password = "fasdfasdfadffsd",
            //         Person = persons[1],
            //         Role = roles[1]
            //         ManagerId = 1,
            //         Branch = branches[0],
            //         PasswordSalt = "fdsfasddf",
            //         UserName = "UserTwo",
            //     },
            //     new User
            //     {
            //         Email = "user3@example.com",
            //         Password = "fasdfasdfadffsd",
            //         Person = persons[2],
            //         RoleId = 1,
            //         ManagerId = 2,
            //         Branch = branches[0],
            //         PasswordSalt = "fdsfasddf",
            //         UserName = "UserThree",
            //     },
            //     new User
            //     {
            //         Email = "user4@example.com",
            //         Password = "fasdfasdfadffsd",
            //         Person = persons[3],
            //         Role = roles[1];
            //         ManagerId = null,
            //         Branch = branches[0],
            //         PasswordSalt = "fdsfasddf",
            //         UserName = "UserFour",
            //     },
            //     new User
            //     {
            //         Email = "user5@example.com",
            //         Password = "fasdfasdfadffsd",
            //         Person = persons[4],
            //         RoleId = 1,
            //         ManagerId = 3,
            //         Branch = branches[0],
            //         PasswordSalt = "fdsfasddf",
            //         UserName = "UserFive",
            //     }
            // };

            List<Branch> branches = new List<Branch>
            {
                new Branch
                {
                    Number = 1,
                    Description = "حي الخليج طريق الملك عبدالله أمام مكتبة جرير",
                    Latitude = 24.789847m,
                    Longitude = 46.807607m,
                    Manager = adminAndManagers[1],
                    City = city1
                },
                new Branch
                {
                    Number = 2,
                    Description =
                        "حي الملز طريق صلاح الدين الأيوبي ( الستين ) أمام مستشفى قوى الأمن",
                    Latitude = 24.789847m,
                    Longitude = 46.807607m,
                    Manager = adminAndManagers[2],
                    City = city2
                },
                new Branch
                {
                    Number = 3,
                    Description = "حي الملك فيصل شارع قس بن ساعدة أمام تموينات سلة الجنان",
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
    }
}
