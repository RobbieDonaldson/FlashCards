using System.Configuration;
using System.Security.Permissions;
using FlashCards.Server.Models.Settings;
using FlashCards.Server.Models.Settings.cs;

namespace FlashCards.Server.Models.Settings
{
    public class AppSettings
    {
        public string? IsProd { get; set; }
        public ConnectionStrings? ConnectionStrings { get; set; }
        public SecuritySettings? Security { get; set; }
        //public SerilogSettings? Serilog { get; set; }
    }
}
