using BirthdayManager.Data.Models;
using MongoDB.Driver;

namespace BirthdayManager.Data.Context.Contract
{
    public interface IMongoBirthdayDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
