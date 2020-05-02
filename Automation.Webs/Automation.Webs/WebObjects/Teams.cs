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
using System.Drawing;

namespace Automation.Webs.WebObjects
{
    class Teams
    {
        private string file;
        Logger log = new Logger(@"D:\Log.txt");

        public enum Location
        {
            Computer,
            OneDrive,
            Recent
        }

        public void Login(Credentials credentials, IWebDriver driver)
        {

           
            driver.Navigate().GoToUrl("https://teams.microsoft.com/");
            driver.FindElement(By.Id("i0116")).SendKeys(credentials.Login);

            driver.FindElement(By.Id("idSIButton9")).Click();

                
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ww = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("i0118")));

            driver.FindElement(By.Id("i0118")).SendKeys(credentials.Password);
            driver.FindElement(By.Id("idSIButton9")).Click();
            driver.FindElement(By.Id("idSIButton9")).Click();
            driver.FindElement(By.ClassName("use-app-lnk")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id=\"toast-container\"]/div/div/div[2]/div/button[2]")).Click(); //skusit urobit krajsie toto je fuj
        }

        public void GoToTeam(string teamName) { //TODO

            using (IWebDriver driver = new ChromeDriver()) {
                driver.FindElement(By.Id("app-bar-2a84919f-59d8-4441-a975-2a8c2643b741")).Click();
                //driver.FindElement(By.CssSelector(string.Format("[title={0}]", teamName))).Click();
            }
        }

        public void UploadFile(Location location, string file, IWebDriver driver)
        {
            this.file = file;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // netusim preco to klikne na dve veci 
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();

            try { // pouzite kvoli pofidernej fcie na Teams
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();
            }
            catch (Exception e) { log.Write("LIFE IS PAIN", "Info"); }



            if (location == Location.Computer) {

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-upload]"))).SendKeys("D:\\Log.txt"); // vyberie moznost Nahrat z PC
            }

            else if (location == Location.OneDrive) {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-personal]"))).Click(); //vyberie moznost nahrat z OD   
                Upload(driver);
            }


            else if (location == Location.Recent) {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-recent]"))).Click(); // vyberie moznost Nahrat z PC
                Upload(driver);
            }
        }

        public void WriteMessage(string message, IWebDriver driver) {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[role=\"textbox\"]"))).SendKeys(message);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("send-message-button"))).Click();
        }

        private void Upload(IWebDriver driver) {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // netusim preco to klikne na dve veci 
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@class=\"ent-name-input\" and text()=\"{this.file}\"]"))).Click();
            }
            catch (Exception e)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
                log.Write("NO FUJ", "Info");
                driver.Close();
                driver.Quit();
            }

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.submitFileSelected(true)\"]"))).Click();

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[aria-label=\"Nahradiť\"]"))).Click();
            }
            catch (Exception e) { log.Write("NO FUJ", "Info"); }

            Thread.Sleep(4000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("send-message-button"))).Click();
        }

    }
}
