namespace apiEmail.Models
{
    public class Email
    {
        public string recipient { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public List<string> carbon_copy_recipients { get; set; }
    }
}
