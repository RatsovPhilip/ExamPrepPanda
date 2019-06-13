using SIS.MvcFramework;
using System;

namespace Panda.Web
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}
