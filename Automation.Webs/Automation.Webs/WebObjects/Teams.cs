using Automation.Webs.Others;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Automation.Webs.WebObjects {
	class Teams {
		public enum Location {
			Computer,
			OneDrive,
			Recent
		}

		public void Login(Credentials credentials) {
			Utils.log.Write("Connecting to https://teams.microsoft.com/", "INFO");

			Utils.browserDriver.driver.Navigate().GoToUrl("https://teams.microsoft.com/");
			Utils.browserDriver.driver.FindElement(By.Id("i0116")).SendKeys(credentials.Login);

			Utils.browserDriver.driver.FindElement(By.Id("idSIButton9")).Click();

			WebDriverWait wait = new WebDriverWait(Utils.browserDriver.driver, TimeSpan.FromSeconds(10));
			IWebElement ww = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("i0118")));

			Utils.browserDriver.driver.FindElement(By.Id("i0118")).SendKeys(credentials.Password);
			Utils.browserDriver.driver.FindElement(By.Id("idSIButton9")).Click();
			Utils.browserDriver.driver.FindElement(By.Id("idSIButton9")).Click();
			Utils.browserDriver.driver.FindElement(By.ClassName("use-app-lnk")).Click();
			Thread.Sleep(5000);
			Utils.browserDriver.driver.FindElement(By.XPath("//*[@id=\"toast-container\"]/div/div/div[2]/div/button[2]")).Click(); //skusit urobit krajsie toto je fuj
		}

		public void GoToTeam(string teamName) { //TODO
			WebDriverWait wait = new WebDriverWait(Utils.browserDriver.driver, TimeSpan.FromSeconds(10));
			Utils.log.Write($"Moving to a channel: {teamName}", "INFO");
			Utils.browserDriver.driver.FindElement(By.Id("app-bar-2a84919f-59d8-4441-a975-2a8c2643b741")).Click();
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[text()='{teamName}']"))).Click();
			Thread.Sleep(10000);
		}

		public void UploadFile(Location location, string file) {
			Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();

			/*if (firstLoad)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();
                firstLoad = false;
            }*/

			// osetrenie kvoli fuj oknu
			try {
				WebDriverWait wait1 = new WebDriverWait(Utils.browserDriver.driver, TimeSpan.FromSeconds(4));
				wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
				wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();
			}
			catch(Exception e) {
				Utils.log.Write(e.ToString(), "ERROR");
			}

			Utils.log.Write($"Uploading files via: {location}", "INFO");
			if (location == Location.Computer) { // TODO             
				Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-upload]"))).SendKeys("D:\\Log.txt"); // vyberie moznost Nahrat z PC
			}
			else if (location == Location.OneDrive) {
				Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-personal]"))).Click(); //vyberie moznost nahrat z OD   
				Upload(file);
			}
			else if (location == Location.Recent) {
				Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-recent]"))).Click(); // vyberie moznost Nahrat z Recent
				Upload(file);
			}
		}

		public void WriteMessage(string message) {
			Utils.log.Write($"Typing a message: \"{message}\"", "INFO");
			Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[role=\"textbox\"]"))).SendKeys(message);
			Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementToBeClickable(By.Id("send-message-button"))).Click();
		}

		private void Upload(string file) {
			try {
				Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@class=\"ent-name-input\" and text()=\"{file}\"]"))).Click();
			}
			catch(Exception e) {
				Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
				Utils.log.Write(e.ToString(), "ERROR");
				Utils.browserDriver.driver.Close();
				Utils.browserDriver.driver.Quit();
			}

			Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.submitFileSelected(true)\"]"))).Click();

			//replace dokumentu
			try {
				Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=\"filesNameCollisionDialog-replaceBtn\"]"))).Click();
			}
			catch(Exception e) {
				Utils.log.Write(e.ToString(), "ERROR");
			}

			Thread.Sleep(5000); //TODO explicit timing for message sending

			Utils.browserDriver.driverWait.Until(ExpectedConditions.ElementToBeClickable(By.Id("send-message-button"))).Click();
			Utils.log.Write("Message sent successfully", "INFO");
		}

	}
}