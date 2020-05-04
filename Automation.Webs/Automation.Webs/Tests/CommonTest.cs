using NUnit.Framework;
using Automation.Webs.Others;
using NUnit.Framework.Interfaces;

namespace Automation.Webs.Tests { [TestFixture]
	class CommonTest {

		[SetUp]
		public void SetUp() {
			Utils.log.Write(TestContext.CurrentContext.Test.Name, "INFO_SETUP");
		}

		[TearDown]
		public void TearDown() {
			var testResult = TestContext.CurrentContext.Result.Outcome;
			if (Equals(testResult, ResultState.Failure) || Equals(testResult == ResultState.Error)) {
				Utils.log.Write(TestContext.CurrentContext.Result.Outcome.ToString(), "ERROR_TEARDOWN");;
			}
			else {
				Utils.log.Write(TestContext.CurrentContext.Result.Outcome.ToString(), "INFO_TEARDOWN");;
			}
		}

	}
}