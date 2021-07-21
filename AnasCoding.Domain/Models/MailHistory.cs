namespace AnasCoding.Domain.Models
{
    public class MailHistory
    {
        public int MailHistoryId { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }
}