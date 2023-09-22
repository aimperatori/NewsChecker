using MimeKit;

namespace UserAuthenticator.Models
{
    public class Message
    {
        public List<MailboxAddress> Destination { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


        public Message(IEnumerable<string> destination, string subject, int userId, string code)
        {
            Destination = new List<MailboxAddress>();
            Destination.AddRange(destination.Select(_ => new MailboxAddress(_, _)));

            Subject = subject;
            Body = $"https://localhost:7175/Active?Id={userId}&Code={code}";
        }
        
    }
}
