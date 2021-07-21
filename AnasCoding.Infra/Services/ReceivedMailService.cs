using AnasCoding.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnasCoding.Infra.Services
{
    public class ReceivedMailService : IReceivedMailService
    {
        public Task<bool> ReceiveEmail(string from, string to, string subject, string body)
        {
            return Task.FromResult(true);
        }
    }
}