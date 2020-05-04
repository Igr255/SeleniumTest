using NUnit.Framework;
using Automation.Webs.Others;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.ComponentModel;

namespace Automation.Webs.Tests
{
    [TestFixture]
    class CommonTest
    {       
        Logger log = new Logger(@"D:\Log.txt");
        [SetUp]
        public void SetUp() {
            log.Write(TestContext.CurrentContext.Test.Name, "INFO_SETUP");
        }

        [TearDown]
        public void TearDown() {
            var testResult = TestContext.CurrentContext.Result.Outcome;
            if (Equals(testResult, ResultState.Failure) || Equals(testResult == ResultState.Error))
            {
                log.Write(TestContext.CurrentContext.Result.Outcome.ToString(), "ERROR_TEARDOWN"); ;
            }
            else {
                log.Write(TestContext.CurrentContext.Result.Outcome.ToString(), "INFO_TEARDOWN"); ;
            }
        }

    }
}
