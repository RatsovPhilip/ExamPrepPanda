using Panda.Data;
using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Panda.Services
{
    public class UsersService : IUsersService
    {
        private readonly PandaDbContext context;

        public UsersService(PandaDbContext context)
        {
            this.context = context;
        }


        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                UserName = username,
                Email = email,
                Password = this.HashPassword(password)
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
            return user.Id;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
