namespace apiEmail.Models
{
    public class SettingsModel
    {
        private string _address;
        private string _smtpServer;
        private int _smtpPort;
        private string _smtpLogin;
        private string _smtpPass;

        public string Address { get => _address; set => _address = value; }
        public string SmtpServer { get => _smtpServer; set => _smtpServer = value; }
        public int SmtpPort { get => _smtpPort; set => _smtpPort = value; }
        public string SmtpLogin { get => _smtpLogin; set => _smtpLogin = value; }
        public string SmtpPass { get => _smtpPass; set => _smtpPass = value; }
    }
}
