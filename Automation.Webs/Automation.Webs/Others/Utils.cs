using Automation.Webs.WebObjects;

namespace Automation.Webs.Others {
	public static class Utils {
		public static BrowserDriver browserDriver;
		public static Logger log = new Logger(@"D:\Log.txt");

		public static void initDriverChrome() {
			browserDriver = new BrowserDriver(browserType.Chrome);
			browserDriver.Start();
		}

		public static void initDriveFirefox() {
			browserDriver = new BrowserDriver(browserType.Firefox);
			browserDriver.Start();
		}
	}
}