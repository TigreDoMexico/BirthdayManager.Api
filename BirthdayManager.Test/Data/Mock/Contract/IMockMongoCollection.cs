using MongoDB.Driver;

namespace BirthdayManager.Test.Data.Mock.Contract
{
    public interface IMockMongoCollection<T> : IMongoCollection<T>
    {
        IFindFluent<T, T> Find(FilterDefinition<T> filter, FindOptions options);
    }
}
