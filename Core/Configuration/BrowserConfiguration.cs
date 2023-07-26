namespace Core.Configuration
{
    public class BrowserConfiguration : IConfiguration
    {
        public string SectionName => "Browser";
        public bool Hedless { get; set; }
        public string Type { get; set; }
        public int TimeOut { get; set; }
        public List<UserModel> ListOfUsers { get; set; }
        public string Site { get; set; }
    }
}