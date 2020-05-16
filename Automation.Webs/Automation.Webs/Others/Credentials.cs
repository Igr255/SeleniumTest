namespace Automation.Webs.Others
{
    public class Credentials
    {
        public Credentials(string login, string password) {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
