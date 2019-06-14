using Panda.Services;
using Panda.Web.ViewModels.Users;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if(inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            var userId = this.usersService.CreateUser(inputModel.Username, inputModel.Email, inputModel.Password);
            this.SignIn(userId,inputModel.Username,inputModel.Email);
            return Redirect("/");
        }
    }
}
