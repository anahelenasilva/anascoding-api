using AnasCoding.Domain.Messaging;

namespace AnasCoding.Infra.Interfaces
{
    public interface ISendMail
    {
        bool SendMail(SendMailRequest request);
    }
}