using System.ComponentModel.DataAnnotations;

namespace apiEmail.Models
 
{
    public class Email
    {
        // Получатель письма. 
        private string _recipient;

        // Тема письма. 
        private string _subject;

        // Содержание письма.
        private string _text;

        // Адресса для копии.
        private List<string> _carbon_copy_recipients; 

        [Required]
        [EmailAddress]
        public string Recipient { get => _recipient; set => _recipient = value; }
        [Required]
        public string Subject { get => _subject; set => _subject = value; }
        [Required]
        public string Text { get => _text; set => _text = value; }
        public List<string> Carbon_copy_recipients { get => _carbon_copy_recipients; set => _carbon_copy_recipients = value; }
    }
}
