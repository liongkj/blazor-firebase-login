namespace Services.Authentication.Firebase
{
    public interface IFirebaseSetting
    {
        public string ApiKey { get; set; }
        public string AuthDomain { get; set; }
    }
}