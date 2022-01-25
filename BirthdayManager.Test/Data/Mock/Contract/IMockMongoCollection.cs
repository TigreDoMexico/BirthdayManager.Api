using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Test.Data.Mock.Contract
{
    public interface IMockMongoCollection<T> : IMongoCollection<T>
    {
        long CountDocuments(Expression<Func<T, bool>> filter);
    }
}
