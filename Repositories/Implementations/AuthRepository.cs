using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Models;

namespace PharmacyAPI.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user, string password)
        {
            // byte[] passwordSalt = null,
            //     passwordHash = null;
            // HashPassword(password, ref passwordHash, ref passwordSalt);

            // user.Password = System.Text.Encoding.UTF8.GetString(passwordHash);
            // user.PasswordSalt = System.Text.Encoding.UTF8.GetString(passwordSalt);

            // await _context.Users.AddAsync(user);
            // await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user is null)
                return null;

            if (!VerifyPassword(user, password))
                return null;

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username);
        }

        private void HashPassword(string password, ref byte[] passwordHash, ref byte[] passwordSalt)
        {
            using (HMACSHA256 HMAC = new HMACSHA256())
            {
                passwordSalt = HMAC.Key;
                byte[] salt = HMAC.Key;
                passwordHash = HMAC.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(User user, string password)
        {
            // using (
            //     HMACSHA256 HMAC = new HMACSHA256(
            //         System.Text.Encoding.UTF8.GetBytes(user.PasswordSalt)
            //     )
            // )
            // {
            //     byte[] newHash = HMAC.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            //     for (int i = 0; i < newHash.Length; i++)
            //     {
            //         if (newHash[i] != user.Password[i])
            //             return false;
            //     }

            return true;
            // }
        }
    }
}
