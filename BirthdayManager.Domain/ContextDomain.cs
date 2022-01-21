using BirthdayManager.Data.Context;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BirthdayManager.Domain
{
    public class ContextDomain
    {
        private readonly MongoBirthdayDbContext _context;

        public ContextDomain(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoSettings:ConnectionStrings").ToString();
            var databaseName = configuration.GetSection("MongoSettings:DatabaseName").ToString();

            _context = new MongoBirthdayDbContext(connectionString, databaseName);
        }

        public IMongoDatabase GetDatabase(string dbName) =>
            _context.Database;
    }
}