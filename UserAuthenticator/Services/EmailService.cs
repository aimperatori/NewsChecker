using MimeKit;
using UserAuthenticator.Models;

namespace UserAuthenticator.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        public void Send(string?[] destination, string subject, int userId, string code)
        {
            Message message = new Message(destination, subject, userId, code);

            var emailMessage = CreateBodyEmail(message);

            SendEmail(emailMessage);
        }

        private void SendEmail(MimeMessage emailMessage)
        {
            /*
            using (var client = new SmtpClient())
            {
                client.Connect(
                    _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                    _configuration.GetValue<int>("EmailSettings:Port"),
                    true
                );
                // nao funciona tem que utilizar OAUTH2 pra autenticar
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(
                    _configuration.GetValue<string>("EmailSettings:From"), 
                    _configuration.GetValue<string>("EmailSettings:Password")
                );

                client.Send(emailMessage);
            }
            */
        }

        private MimeMessage CreateBodyEmail(Message message)
        {
            var msg = new MimeMessage();

            var from = _configuration.GetValue<string>("EmailSettings:From");

            msg.From.Add(new MailboxAddress(from, from));
            msg.To.AddRange(message.Destination);
            msg.Subject = message.Subject;
            msg.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Body
            };

            return msg;
        }
    }
}
