using Automation.Webs.Others;
using Automation.Webs.Tests;
using Automation.Webs.WebObjects;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Webs
{
    public class Class1
    {

        public static void Main(string[] args)
        {
            CommonTest ct = new CommonTest();
            BrowserDriver bd = new BrowserDriver(BrowserDriver.browserType.Chrome);
            TeamObjects to = new TeamObjects();

            Credentials cr = new Credentials("Petko");
            cr.Login = "dlp.automation3@safeticadlptesting.onmicrosoft.com";
            cr.Password = "Password.dlp";

            to.Login(cr);
        }

        
    }
}
