using MongoDB.Driver;

namespace BirthdayManager.Data
{
    public class MongoDbContext
    {
        public MongoClient Database { get; private set; }
        
        public MongoDbContext(string connectionString)
        {
            Database = new MongoClient(connectionString);
        }
    }
}