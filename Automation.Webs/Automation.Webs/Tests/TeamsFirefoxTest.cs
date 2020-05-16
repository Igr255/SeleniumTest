using NUnit.Framework;
using Automation.Webs.Others;
using Automation.Webs.WebObjects;

namespace Automation.Webs.Tests { 
	[TestFixture]
	class TeamsFirefoxTest: CommonTest {
		Credentials cr = new Credentials("dlp.automation3@safeticadlptesting.onmicrosoft.com", "Password.dlp");
		Teams teams = new Teams();

		[SetUp]
		public void OneTimeSetUp() {
			Teams.initDriverChrome();
			teams.Login(cr);
			teams.GoToTeam("Test");
		}

		[Test]
		public void Test1() {
			teams.UploadFile(Location.OneDrive, "SeleniumNUnitProject.docx");
			teams.WriteMessage("File 1 Test");
		}

		[Test]
		public void Test2() {
			teams.UploadFile(Location.OneDrive, "WordFile.docx");
			teams.WriteMessage("File Word Test");
		}

		[Test]
		public void Test3() {
			teams.UploadFile(Location.OneDrive, "ExcelFile.xlsx");
			teams.WriteMessage("File Excel Test");
		}

		[Test]
		public void Test4() {
			teams.UploadFile(Location.Recent, "SeleniumNUnitProject.docx");
			teams.WriteMessage("File Recent Test");
		}

		[TearDown]
		public void OneTimeTearDown() {
			Teams.browserDriver.Close();
		}

	}
}