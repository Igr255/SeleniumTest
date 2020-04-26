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
        string link = "https://teams.microsoft.com/_#/conversations/V%C5%A1eobecn%C3%A9?threadId=19:6623609b5e9d485f9e53fcfad196a653@thread.tacv2&ctx=channel";

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

                Assert.AreEqual(link, @"https://teams.microsoft.com/_#/conversations/V%C5%A1eobecn%C3%A9?threadId=19:6623609b5e9d485f9e53fcfad196a653@thread.tacv2&ctx=channel");
                Thread.Sleep(30000000);
            }

        }

        public void GoToTeam(string teamName) {
            using (IWebDriver driver = new ChromeDriver()) {
                driver.FindElement(By.CssSelector("[title={0}]"));
            }

        }

    }
}
