using System.ComponentModel.DataAnnotations;

namespace AnasCoding.Domain.Messaging
{
    public class SendMailRequest
    {
        [Required]
        [StringLength((200))]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string From { get; set; }

        [Required]
        [StringLength((200))]
        public string Subject { get; set; }

        [Required]
        [StringLength((500))]
        public string Body { get; set; }
    }
}