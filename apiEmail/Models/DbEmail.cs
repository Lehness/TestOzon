using System.Text.Json;

namespace apiEmail.Models
{
    public class DbEmail
    {
        private int _id;
        private string _recipient;
        private string _subject;
        private string _text;
        private string _carbon_copy_recipients;
        private DateTime _dateTime;
        private string _result;
      


        public DbEmail(Email email, string res)
        {
            Recipient = email.Recipient;
            Subject = email.Subject;
            Text = email.Text;
            string jsonCopy = JsonSerializer.Serialize(email.Carbon_copy_recipients);
            Carbon_copy_recipients = jsonCopy;
            DateTime = System.DateTime.Today;
            Result = res;
        }

        public int Id { get => _id; set => _id = value; }
        public string Recipient { get => _recipient; set => _recipient = value; }
        public string Subject { get => _subject; set => _subject = value; }
        public string Text { get => _text; set => _text = value; }
        public string Carbon_copy_recipients { get => _carbon_copy_recipients; set => _carbon_copy_recipients = value; }
        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }
        public string Result { get => _result; set => _result = value; }
    }
}
