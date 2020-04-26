using Automation.Webs.Others;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit;
using System.Threading;

namespace Automation.Webs.WebObjects
{
    public class BrowserDriver
    {
        Logger log = new Logger(@"D:\Log.txt");

        public enum browserType
        {
            Chrome,
            Firefox
        }
        public browserType DriverType { get; set; }

        public BrowserDriver(browserType browserType)
        {
            DriverType = browserType;
        }

        public void Start() {
            if (DriverType == browserType.Chrome)
            {
                log.Write("Starting Chrome browser", "Info");
                using (IWebDriver driver = new ChromeDriver())
                {
                    driver.Navigate().GoToUrl("https://teams.microsoft.com/");
                }
            }
            else if (DriverType == browserType.Firefox)
            {
                log.Write("Starting Firefox browser", "Info");
                using (IWebDriver driver = new FirefoxDriver())
                {
                    driver.Navigate().GoToUrl("https://teams.microsoft.com/");
                }
            }
        }

        public void Close() {
            using (IWebDriver driver = new ChromeDriver())
            {
                log.Write("Closing the browser", "Info");
                driver.Quit();
            }
        }

       

    }
}
