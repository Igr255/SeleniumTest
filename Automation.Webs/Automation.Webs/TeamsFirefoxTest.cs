using Automation.Webs.Tests;
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
    class TeamsFirefoxTest: CommonTest
    {
        Credentials cr = new Credentials("dlp.automation3@safeticadlptesting.onmicrosoft.com", "Password.dlp");
        BrowserDriver browserDriver = new BrowserDriver(BrowserDriver.browserType.Firefox);
        Teams teams = new Teams();



        [SetUp]
        public void OneTimeSetUp()
        {
            teams.Driver = browserDriver.Start();
            teams.Login(cr);
            teams.GoToTeam("Test");
        }

        [Test]
        public void Test1()
        {
            teams.UploadFile(Teams.Location.OneDrive, "SeleniumNUnitProject.docx");
            teams.WriteMessage("File 1 Test");
        }

        [Test]
        public void Test2()
        {
            teams.UploadFile(Teams.Location.OneDrive, "WordFile.docx");
            teams.WriteMessage("File Word Test");
        }

        [Test]
        public void Test3()
        {
            teams.UploadFile(Teams.Location.OneDrive, "ExcelFile.xlsx");
            teams.WriteMessage("File Excel Test");
        }

        [Test]
        public void Test4()
        {
            teams.UploadFile(Teams.Location.Recent, "SeleniumNUnitProject.docx");
            teams.WriteMessage("File Recent Test");
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            browserDriver.Close();
        }

    }
}
