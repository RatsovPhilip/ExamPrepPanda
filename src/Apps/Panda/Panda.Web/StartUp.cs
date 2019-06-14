using Panda.Data;
using Panda.Services;
using Panda.Web.ViewModels.Packages;
using Panda.Web.ViewModels.Reciepts;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;
using System.Collections.Generic;
using System.Text;

namespace Panda.Web
{
    public class StartUp : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using(var db = new PandaDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUsersService, UsersService>();
            serviceProvider.Add<IPackagesService, PackagesService>();
            serviceProvider.Add<IReceiptsService, ReceiptsService>();
        }
    }
}
