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
        private IWebDriver driver;

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
            if (DriverType == browserType.Chrome)
            {
                log.Write("Starting Chrome browser", "INFO");
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);               
            }

            else {
                log.Write("Starting Firefox browser", "INFO");                
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public void Close() {            
            log.Write("Closing the browser", "INFO");
            driver.Close();
            driver.Quit();            
        }

       

    }
}
