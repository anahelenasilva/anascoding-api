using System.Threading.Tasks;
using AnasCoding.Domain.Messaging;

namespace AnasCoding.Infra.Interfaces
{
    public interface ISendMail
    {
        Task<string> SendMail(SendMailRequest request);
    }
}