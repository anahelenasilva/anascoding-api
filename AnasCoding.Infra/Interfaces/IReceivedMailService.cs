using System.Threading.Tasks;

namespace AnasCoding.Infra.Interfaces
{
    public interface IReceivedMailService
    {
        Task<bool> ReceiveEmail(string from, string to, string subject, string body);
    }
}