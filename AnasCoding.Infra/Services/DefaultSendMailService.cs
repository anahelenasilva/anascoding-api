using AnasCoding.Domain.Messaging;
using AnasCoding.Infra.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace AnasCoding.Infra.Services
{
    public class DefaultSendMailService : ISendMail
    {
        private readonly IKeyVaultSecretService _secretService;

        public DefaultSendMailService(IKeyVaultSecretService secretService)
        {
            _secretService = secretService;
        }

        public string SendMail(SendMailRequest request)
        {
            try
            {
                string emailFrom = _secretService.RetornarSegredo("SEND-MAIL-EMAIL");
                string senhaFrom = _secretService.RetornarSegredo("SEND-MAIL-PWD");

                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("Site anascoding", emailFrom));
                mailMessage.To.Add(new MailboxAddress(request.Name, request.From));
                mailMessage.Subject = request.Subject;
                mailMessage.Body = new TextPart("plain")
                {
                    Text = request.Body
                };

                using var smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(emailFrom, senhaFrom);
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);

                return "true";
            }
            catch (Exception e)
            {
                //TODO log erro

                var msg = $"{e.Message} {e.InnerException?.Message}";

                return msg;
            }
        }
    }
}