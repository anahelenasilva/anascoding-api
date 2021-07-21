using AnasCoding.Domain.Models;

namespace AnasCoding.Infra.Interfaces
{
    public interface IMailHistory
    {
        int CreateHistory(MailHistory mailHistory);
    }
}