using BirthdayManager.Data.Context.Contract;
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

        public MongoBirthdayDbContext(string connection, string database)
        {
            _client = new MongoClient(connection);
            _db = _client.GetDatabase(database);
        }

        public IMongoCollection<T> GetCollection<T>(string name) =>
            _db.GetCollection<T>(name);
    }
}
