using System;
using System.IO;

namespace Automation.Webs.Others
{    
    public class Logger
    {
        private string dir;

        public Logger(string dir) {
            this.dir = dir;
        }

        public void Write(string message, string errorState) {

            using (StreamWriter sw = File.AppendText(dir)) {
                sw.WriteLine("<{0}> [{1}] {2}", DateTime.Now.ToLongTimeString(), errorState, message);
            }

        }


    }
}
