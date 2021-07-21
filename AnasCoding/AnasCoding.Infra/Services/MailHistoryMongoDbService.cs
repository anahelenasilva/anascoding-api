using AnasCoding.Domain.Models;
using AnasCoding.Infra.Interfaces;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace AnasCoding.Infra.Services
{
    public class MailHistoryMongoDbService : IMailHistory
    {
        private readonly IConfiguration configuration;

        public MailHistoryMongoDbService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public int CreateHistory(MailHistory mailHistory)
        {
            var client = new MongoClient("mongodb+srv://<username>:<password>@<cluster-address>/test?w=majority"
);
            var database = client.GetDatabase("test");

            //configuration.GetConnectionString
            throw new NotImplementedException();
        }
    }
}