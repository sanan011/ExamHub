namespace ExamHub
{
    public abstract class UserBase
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserBase(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public abstract void Login();
    }
}
