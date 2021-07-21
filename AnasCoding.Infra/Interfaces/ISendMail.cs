using AnasCoding.Domain.Messaging;

namespace AnasCoding.Infra.Interfaces
{
    public interface ISendMail
    {
        string SendMail(SendMailRequest request);
    }
}