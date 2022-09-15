using System.Text.Json;

namespace apiEmail.Models
{
    public class DbEmail
    {
        public int Id { get; set; }
        public string recipient { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public string carbon_copy_recipients { get; set; }
        public DateTime dateTime { get; set; }
        public string result { get; set; }

        public DbEmail() { }

        public DbEmail(Email email, string res)
        {
            recipient = email.recipient;
            subject = email.subject;
            text = email.text;
            string jsonCopy = JsonSerializer.Serialize(email.carbon_copy_recipients);
            carbon_copy_recipients = jsonCopy;
            dateTime = System.DateTime.Today;
            result = res;
        }
    }
}
