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

        public IWebDriver Start() {
            IWebDriver driver;
            if (DriverType == browserType.Chrome)
            {
                log.Write("Starting Chrome browser", "Info");
                driver = new ChromeDriver();
            }
            else {
                log.Write("Starting Firefox browser", "Info");
                driver = new FirefoxDriver();
            }
            return driver;
        }

        public void Close() {
            using (IWebDriver driver = new ChromeDriver())
            {
                log.Write("Closing the browser", "Info");
                driver.Close();
                driver.Quit();
            }
        }

       

    }
}
