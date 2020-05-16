using NUnit.Framework;
using Automation.Webs.Others;
using Automation.Webs.WebObjects;

namespace Automation.Webs.Tests { 
	[TestFixture]
	public class TeamsChromeTest: CommonTest {
		private Credentials _cr = new Credentials("dlp.automation3@safeticadlptesting.onmicrosoft.com", "Password.dlp");
		private Teams _teams = new Teams();

		[SetUp]
		public void OneTimeSetUp() {
			Teams.initDriverChrome();
			_teams.Login(_cr);
			_teams.GoToTeam("Test");
		}

		[Test]
		public void Test1() {
			Utils.log.Write("Starting Test1...", "TEST");
			_teams.UploadFile(Location.OneDrive, "SeleniumNUnitProject.docx");
			_teams.WriteMessage("File 1 Test");
		}

		[Test]
		public void Test2() {
			Utils.log.Write("Starting Test2...", "TEST");
			_teams.UploadFile(Location.OneDrive, "WordFile.docx");
			_teams.WriteMessage("File Word Test");
		}

		[Test]
		public void Test3() {
			Utils.log.Write("Starting Test3...", "TEST");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
			_teams.WriteMessage("File Excel Test");
		}

		[Test]
		public void Test4() {
			Utils.log.Write("Starting Test4...", "TEST");
			_teams.UploadFile(Location.Recent, "SeleniumNUnitProject.docx");
			_teams.UploadFile(Location.Recent, "SeleniumNUnitProject.docx");
			_teams.UploadFile(Location.Recent, "WordFile.docx");
			_teams.UploadFile(Location.Recent, "WordFile.docx");
			_teams.UploadFile(Location.Recent, "ExcelFile.xlsx");
			_teams.UploadFile(Location.Recent, "ExcelFile.xlsx");
			_teams.WriteMessage("File Recent Test");
		}

		[TearDown]
		public void OneTimeTearDown() {
			Teams.browserDriver.Close();
		}

	}
}