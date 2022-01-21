using MongoDB.Driver;

namespace BirthdayManager.Data.Context.Contract
{
    internal interface IMongoBirthdayDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
