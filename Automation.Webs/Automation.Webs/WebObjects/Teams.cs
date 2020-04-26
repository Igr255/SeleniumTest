using Automation.Webs.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit;
using System.Threading;
using NUnit.Framework;
using Automation.Webs.Others;
using NUnit.Framework.Interfaces;


namespace Automation.Webs.WebObjects
{
    class Teams
    {
        public enum Location
        {
            Computer,
            OneDrive,
            Recent
        }

        public void Login(Credentials credentials)
        {

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://teams.microsoft.com/");
                driver.FindElement(By.Id("i0116")).SendKeys(credentials.Login);

                driver.FindElement(By.Id("idSIButton9")).Click();

                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(35));
                IWebElement ww = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("i0118")));

                driver.FindElement(By.Id("i0118")).SendKeys(credentials.Password);
                driver.FindElement(By.Id("idSIButton9")).Click();
                driver.FindElement(By.Id("idSIButton9")).Click();
                driver.FindElement(By.ClassName("use-app-lnk")).Click();
                Thread.Sleep(10000);

                
                
                Thread.Sleep(34545);
            }

        }

        public void GoToTeam(string teamName) { //TODO

            using (IWebDriver driver = new ChromeDriver()) {
                driver.FindElement(By.Id("app-bar-2a84919f-59d8-4441-a975-2a8c2643b741")).Click();
                //driver.FindElement(By.CssSelector(string.Format("[title={0}]", teamName))).Click();
            }
        }

        public void UploadFile(Location location, string file)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(35)); // netusim preco to klikne na dve veci 
                IWebElement applyLink = wait.Until(d => d.FindElement(By.ClassName("icons-attachment")));
                applyLink.Click();

                if (location == Location.Computer)
                {
                    driver.FindElement(By.CssSelector("[data-tid=fwn-upload]")).Click();
                }
                else if (location == Location.OneDrive) {
                    driver.FindElement(By.CssSelector("[data-tid=fwn-personal]")).Click();
                }
                else if (location == Location.Recent) {
                    driver.FindElement(By.CssSelector("[data-tid=fwn-recent]")).Click();
                }
            }
           

        }

        
        

    }
}
