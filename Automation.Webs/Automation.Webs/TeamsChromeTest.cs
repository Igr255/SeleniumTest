using Automation.Webs.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Automation.Webs.Others;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Automation.Webs.WebObjects;

namespace Automation.Webs
{
    [TestFixture]
    class TeamsChromeTest: CommonTest
    {

        Credentials cr = new Credentials("dlp.automation3@safeticadlptesting.onmicrosoft.com", "Password.dlp");
        BrowserDriver browserDriver = new BrowserDriver(BrowserDriver.browserType.Chrome);
        Teams teams = new Teams();


        IWebDriver driver = browserDriver.Start();
        [SetUp]
        public void OneTimeSetUp() {
            
            using (driver)
            {
                teams.Login(cr, driver);
                teams.GoToTeam("Automation"); //fix

            }
        }

        [Test]
        public void Test1() {
            teams.UploadFile(Teams.Location.OneDrive, "SeleniumNUnitProject.docx", driver);       
        }

        [TearDown]
        public void OneTimeTearDown() {
            browserDriver.Close();
        }

        
    }
}
