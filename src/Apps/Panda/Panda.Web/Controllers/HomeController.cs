using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet(Url="/")]
        public IActionResult IndexEmpty()
        {
            return this.Index();
        }

        //Home/Index
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
