using Automation.Webs.Others;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Webs.WebObjects {
    public enum Location
    {
        Computer,
        OneDrive,
        Recent
    }
    public class Teams {

        public static BrowserDriver browserDriver;

        public static void initDriverChrome()
        {
            browserDriver = new BrowserDriver(browserType.Chrome);
            browserDriver.Start();   
        }

        public static void initDriveFirefox()
        {
            browserDriver = new BrowserDriver(browserType.Firefox);
            browserDriver.Start();
        }



        // [FindsBy(How = How.Id, Using = "idSIButton9")]
        // private IWebElement loginButton { get; set;}

        private string loginButton = "idSIButton9"; // tlacitko next pri logine

        public void Login(Credentials credentials) {
   
            Utils.log.Write("Connecting to https://teams.microsoft.com/", "INFO");

			browserDriver.driver.Navigate().GoToUrl("https://teams.microsoft.com/");
            browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("i0116"))).SendKeys(credentials.Login); //login field

            browserDriver.driver.FindElement(By.Id(loginButton)).Click();

            browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("i0118")));

			browserDriver.driver.FindElement(By.Id("i0118")).SendKeys(credentials.Password); // password field
			browserDriver.driver.FindElement(By.Id(loginButton)).Click();
			browserDriver.driver.FindElement(By.Id(loginButton)).Click();
			browserDriver.driver.FindElement(By.ClassName("use-app-lnk")).Click();
			browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"toast-container\"]/div/div/div[2]/div/button[2]"))).Click(); //skusit urobit krajsie toto je fuj
		}

		public void GoToTeam(string teamName) { //TODO
			Utils.log.Write($"Moving to a channel: {teamName}", "INFO");
			browserDriver.driver.FindElement(By.Id("app-bar-2a84919f-59d8-4441-a975-2a8c2643b741")).Click(); //click na polozku Teams
            browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[text()='{teamName}']"))).Click(); //click na specificky team channel
			Thread.Sleep(10000);
		}

		    public void UploadFile(Location location, string file) {
			    browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();

			    try {
				    WebDriverWait wait1 = new WebDriverWait(browserDriver.driver, TimeSpan.FromSeconds(4));
				    wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
				    wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();
			    }
			    catch(Exception e) {
				    Utils.log.Write(e.ToString(), "ERROR");
			    }

			    Utils.log.Write($"Uploading files via: {location}", "INFO");
			    if (location == Location.Computer) { // TODO             
				    browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-upload]"))).SendKeys("D:\\Log.txt"); // vyberie moznost Nahrat z PC
			    }
			    else if (location == Location.OneDrive) {
				    browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-personal]"))).Click(); //vyberie moznost nahrat z OD   
				    Upload(file);
			    }
			    else if (location == Location.Recent) {
				    browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-recent]"))).Click(); // vyberie moznost Nahrat z Recent
				    Upload(file);
			    }
		    }

		public void WriteMessage(string message) {
			Utils.log.Write($"Typing a message: \"{message}\"", "INFO");
			browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[role=\"textbox\"]"))).SendKeys(message); //poslanie spravy
			browserDriver.driverWait.Until(ExpectedConditions.ElementToBeClickable(By.Id("send-message-button"))).Click();
		}

		private void Upload(string file) {
			try {
				browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@class=\"ent-name-input\" and text()=\"{file}\"]"))).Click();
			}
			catch(Exception e) {
				browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click(); //specificky subor nebol najdeny
				Utils.log.Write(e.ToString(), "ERROR");
				browserDriver.driver.Close();
				browserDriver.driver.Quit();
			}

			browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.submitFileSelected(true)\"]"))).Click();

			//replace dokumentu
			try {
				browserDriver.driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=\"filesNameCollisionDialog-replaceBtn\"]"))).Click();
			}
			catch(Exception e) {
				Utils.log.Write(e.ToString(), "ERROR");
			}

			Thread.Sleep(5000); //TODO explicit timing for message sending

			browserDriver.driverWait.Until(ExpectedConditions.ElementToBeClickable(By.Id("send-message-button"))).Click();
			Utils.log.Write("Message sent successfully", "INFO");
		}

	}
}