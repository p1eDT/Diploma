namespace Core
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public override string? ToString()
        {
            return $"Name: {Name} Password:{Password}";
        }
    }
}