using Panda.Services;
using Panda.Web.ViewModels.Packages;
using SIS.MvcFramework;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;

        public PackagesController(IPackagesService packagesService, IUsersService usersService)
        {
            this.packagesService = packagesService;
            this.usersService = usersService;
        }

        public IActionResult Create()
        {
            var list = this.usersService.GetAllUserNames();
            return this.View(list);
        }


    }
}
