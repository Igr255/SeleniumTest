using Automation.Webs.Others;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation.Webs.WebObjects {
	public class BrowserDriver {
		public IWebDriver driver;
		public WebDriverWait driverWait;

		public enum browserType {
			Chrome,
			Firefox
		}
		public browserType DriverType {
			get;
			set;
		}

		public BrowserDriver(browserType browserType) {
			DriverType = browserType;
		}

		public void Start() {
			if (DriverType == browserType.Chrome) {
				Utils.log.Write("Starting Chrome browser", "INFO");
				ChromeOptions options = new ChromeOptions();
				options.AddArgument("--start-maximized");
				driver = new ChromeDriver(options);
			}

			else {
				Utils.log.Write("Starting Firefox browser", "INFO");
				driver = new FirefoxDriver();
				driver.Manage().Window.Maximize();
			}
			driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		public void Close() {
			Utils.log.Write("Closing the browser", "INFO");
			driver.Close();
			driver.Quit();
		}

	}
}