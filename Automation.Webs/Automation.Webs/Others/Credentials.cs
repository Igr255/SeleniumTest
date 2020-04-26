
namespace Automation.Webs.Others
{
    class Credentials
    {
        private string name;

        public Credentials(string name) {
            this.name = name;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
