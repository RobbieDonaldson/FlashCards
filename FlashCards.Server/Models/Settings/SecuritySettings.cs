namespace FlashCards.Server.Models.Settings.cs
{
    public class SecuritySettings
    {
        public string? JWTIssuer { get; set; }
        public string? JWTAudience { get; set; }
        public string? JWTKey { get; set; }
    }
}
