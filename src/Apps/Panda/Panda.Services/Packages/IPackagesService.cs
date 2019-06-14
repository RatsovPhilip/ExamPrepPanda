using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services.Packages
{
    public interface IPackagesService
    {
        void Create(string description, decimal weight, string shippingAdrres, string recipientName);

        IQueryable<Package> GetAllByStatus(PackageStatus status);
    }
}
