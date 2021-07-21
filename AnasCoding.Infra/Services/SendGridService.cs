using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using AnasCoding.Domain.Messaging;
using AnasCoding.Infra.Interfaces;

namespace AnasCoding.Infra.Services
{
    public class SendGridService : ISendMail
    {
        private readonly IKeyVaultSecretService _secretService;

        public SendGridService(IKeyVaultSecretService secretService)
        {
            _secretService = secretService;
        }

        public async Task<string> SendMail(SendMailRequest request)
        {
            try
            {
                string apiKey = _secretService.RetornarSegredo("SEND-GRID-APIKEY");
                var client = new SendGridClient(apiKey);

                var from = new EmailAddress(request.From, request.Name);
                var subject = request.Subject;

                var to = new EmailAddress("anahelenarp@hotmail.com", "anascodingapi");
                var plainTextContent = request.Body;

                var htmlContent = "<strong>Sent via API</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                return Task.FromResult($"success: {response.IsSuccessStatusCode}").Result;
            }
            catch (Exception e)
            {
                //TODO log error

                var msg = $"{e.Message} {e.InnerException?.Message}";
                return Task.FromResult(msg).Result;
            }
        }
    }
}