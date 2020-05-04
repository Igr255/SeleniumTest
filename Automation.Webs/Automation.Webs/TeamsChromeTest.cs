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
    class TeamsChromeTest: CommonTest
    {
        Logger log = new Logger(@"D:\Log.txt");
        Credentials cr = new Credentials("dlp.automation3@safeticadlptesting.onmicrosoft.com", "Password.dlp");
        BrowserDriver browserDriver = new BrowserDriver(BrowserDriver.browserType.Chrome);
        Teams teams = new Teams();


        
        [SetUp]
        public void OneTimeSetUp() {
            teams.Driver = browserDriver.Start();  
            teams.Login(cr);
            teams.GoToTeam("Test"); //fix
            
        }

        [Test]
        public void Test1() {
            log.Write("Starting Test1...", "TEST");
            teams.UploadFile(Teams.Location.OneDrive, "SeleniumNUnitProject.docx");
            teams.WriteMessage("File 1 Test");
        }

        [Test]
        public void Test2()
        {
            log.Write("Starting Test2...", "TEST");
            teams.UploadFile(Teams.Location.OneDrive, "WordFile.docx");
            teams.WriteMessage("File Word Test");
        }

        [Test]
        public void Test3()
        {
            log.Write("Starting Test3...", "TEST");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
            teams.WriteMessage("File Excel Test");
        }

        [Test]
        public void Test4()
        {
            log.Write("Starting Test4...", "TEST");
            teams.UploadFile(Teams.Location.Recent, "SeleniumNUnitProject.docx");
            teams.UploadFile(Teams.Location.Recent, "SeleniumNUnitProject.docx");
            teams.UploadFile(Teams.Location.Recent, "WordFile.docx");
            teams.UploadFile(Teams.Location.Recent, "WordFile.docx");
            teams.UploadFile(Teams.Location.Recent, "ExcelFile.xlsx");
            teams.UploadFile(Teams.Location.Recent, "ExcelFile.xlsx");
            teams.WriteMessage("File Recent Test");
        }

        [TearDown]
        public void OneTimeTearDown() {
            browserDriver.Close();
        }

        
    }
}
