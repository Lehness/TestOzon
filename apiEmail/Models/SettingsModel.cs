namespace apiEmail.Models
{
    public class SettingsModel
    {
        public string Address { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpLogin { get; set; }
        public string SmtpPass { get; set; }

    }
}
