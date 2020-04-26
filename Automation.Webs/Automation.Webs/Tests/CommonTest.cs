using NUnit.Framework;
using Automation.Webs.Others;
using NUnit.Framework.Interfaces;

namespace Automation.Webs.Tests
{
    [TestFixture]
    class CommonTest
    {
        Logger log = new Logger(@"D:\Log.txt");

        [SetUp]
        public void SetUp() {
            log.Write(TestContext.CurrentContext.Test.Name, "Info");
        }

        [TearDown]
        public void TearDown() {
            var testResult = TestContext.CurrentContext.Result.Outcome;
            if (Equals(testResult, ResultState.Failure) || Equals(testResult == ResultState.Error))
            {
                log.Write(TestContext.CurrentContext.Result.Outcome.ToString(), "Error"); ;
            }
            else {
                log.Write(TestContext.CurrentContext.Result.Outcome.ToString(), "Info"); ;
            }
        }

    }
}
