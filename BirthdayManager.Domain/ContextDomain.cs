using BirthdayManager.Data.Context;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BirthdayManager.Domain
{
    public class ContextDomain
    {
        private readonly MongoDbContext _context;

        public ContextDomain(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            _context = new MongoDbContext(connectionString);
        }

        public IMongoDatabase GetDatabase(string dbName) =>
            _context.Database.GetDatabase(dbName);
    }
}