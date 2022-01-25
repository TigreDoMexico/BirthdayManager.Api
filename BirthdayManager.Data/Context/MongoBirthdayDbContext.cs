using BirthdayManager.Data.Context.Contract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Data.Context
{
    public class MongoBirthdayDbContext : IMongoBirthdayDbContext
    {
        private IMongoDatabase _db;
        private MongoClient _client;

        public IClientSessionHandle Session { get; set; }
        public IMongoDatabase Database { get { return _db; } }

        public MongoBirthdayDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoSettings:ConnectionStrings").Value;
            var databaseName = configuration.GetSection("MongoSettings:DatabaseName").Value;

            _client = new MongoClient(connectionString);
            _db = _client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name) =>
            _db.GetCollection<T>(name);
    }
}
