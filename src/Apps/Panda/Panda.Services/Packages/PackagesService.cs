using Panda.Data;
using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services.Packages
{
    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext context;

        public PackagesService(PandaDbContext context)
        {
            this.context = context;
        }

        public void Create(string description, decimal weight, string shippingAdrres, string recipientName)
        {
            var userId = this.context.Users.Where(x => x.UserName == recipientName)
                .Select(u => u.Id).FirstOrDefault();

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = PackageStatus.Pending,
                ShippingAddress = shippingAdrres,
                RecipientId = userId
            };

            this.context.Packages.Add(package);
            this.context.SaveChanges();
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status)
        {
            var packages = this.context.Packages.Where(x => x.Status == status);
            return packages;
        }
    }
}
