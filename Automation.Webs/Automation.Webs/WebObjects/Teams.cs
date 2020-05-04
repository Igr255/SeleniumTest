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
        private bool firstLoad = true;
        public IWebDriver Driver { get; set; }

        private string file;
        Logger log = new Logger(@"D:\Log.txt");

        public enum Location
        {
            Computer,
            OneDrive,
            Recent
        }

        public void Login(Credentials credentials)
        {
            log.Write("Connecting to https://teams.microsoft.com/", "INFO");

            Driver.Navigate().GoToUrl("https://teams.microsoft.com/");
            Driver.FindElement(By.Id("i0116")).SendKeys(credentials.Login);

            Driver.FindElement(By.Id("idSIButton9")).Click();

                
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement ww = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("i0118")));

            Driver.FindElement(By.Id("i0118")).SendKeys(credentials.Password);
            Driver.FindElement(By.Id("idSIButton9")).Click();
            Driver.FindElement(By.Id("idSIButton9")).Click();
            Driver.FindElement(By.ClassName("use-app-lnk")).Click();
            Thread.Sleep(5000);
            Driver.FindElement(By.XPath("//*[@id=\"toast-container\"]/div/div/div[2]/div/button[2]")).Click(); //skusit urobit krajsie toto je fuj
        }

        public void GoToTeam(string teamName) { //TODO
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            log.Write($"Moving to a channel: {teamName}", "INFO");
            Driver.FindElement(By.Id("app-bar-2a84919f-59d8-4441-a975-2a8c2643b741")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//span[text()='{0}']", teamName)))).Click();
            Thread.Sleep(10000);
        }

        public void UploadFile(Location location, string file)
        {
            this.file = file;

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); // netusim preco to klikne na dve veci 
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();

            /*if (firstLoad)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();
                firstLoad = false;
            }        */    

            try { // pouzite kvoli pofidernej fcie na Teams
                WebDriverWait wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
                wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
                wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[track-summary=\"Add attachment\"]"))).Click();
            }
            catch (Exception e) { log.Write("", "INFO"); }


            log.Write($"Uploading files via: {location}", "INFO");
            if (location == Location.Computer) {                
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-upload]"))).SendKeys("D:\\Log.txt"); // vyberie moznost Nahrat z PC
            }

            else if (location == Location.OneDrive) {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-personal]"))).Click(); //vyberie moznost nahrat z OD   
                Upload();
            }


            else if (location == Location.Recent) {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=fwn-recent]"))).Click(); // vyberie moznost Nahrat z PC
                Upload();
            }
        }

        public void WriteMessage(string message) {
            log.Write($"Typing a message: \"{message}\"", "INFO");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[role=\"textbox\"]"))).SendKeys(message);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("send-message-button"))).Click();
        }

        private void Upload() {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); // netusim preco to klikne na dve veci 
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@class=\"ent-name-input\" and text()=\"{this.file}\"]"))).Click();
            }
            catch (Exception e)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.closeDialog()\"]"))).Click();
                log.Write(e.ToString(), "ERROR");
                Driver.Close();
                Driver.Quit();
            }

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng-click=\"$ctrl.submitFileSelected(true)\"]"))).Click();

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-tid=\"filesNameCollisionDialog-replaceBtn\"]"))).Click();
            }
            catch (Exception e) { 
                log.Write(e.ToString(), "ERROR");
            }

            Thread.Sleep(5000); //TODO explicit timing for message sending

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("send-message-button"))).Click();
            log.Write("Message sent successfully", "INFO");
        }

    }
}
