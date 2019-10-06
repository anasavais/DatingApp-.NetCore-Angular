using System;
using System.Threading.Tasks;
using DatingApp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
          _context = context;

        }
        public async Task<User> Login(string UserName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserName == UserName);
            if(user==null)
            {
                return null;
            }
            if(!VerifyUserPassword(password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }
            return user;

        }

        private bool VerifyUserPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac =new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputedHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0 ; i< ComputedHash.Length ; i++)
                {
                    if( ComputedHash[i] != passwordHash[i])return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] PasswordHash,PasswordSalt;
            GetPasswordHash(password,out PasswordHash,out PasswordSalt);
            user.PasswordHash = PasswordHash;
            user.PasswordSalt= PasswordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void GetPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac =new System.Security.Cryptography.HMACSHA512())
            {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }

        public async Task<bool> UserExists(string UserName)
        {
            if( await _context.Users.AnyAsync(x=>x.UserName == UserName))
            {
                return true;
            }
            return false;
        }
    }
}