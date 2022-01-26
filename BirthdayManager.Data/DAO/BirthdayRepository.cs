using BirthdayManager.Data.Context;
using BirthdayManager.Data.Context.Contract;
using BirthdayManager.Data.DAO.Contract;
using BirthdayManager.Data.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Data.DAO
{
    public class BirthdayRepository : IRepository<Birthday>
    {
        private const string COLLECTION_NAME = "Birthday";

        private IMongoBirthdayDbContext _context;
        private IMongoCollection<Birthday> _collection;

        public BirthdayRepository(IConfiguration configuration)
        {
            _context = new MongoBirthdayDbContext(configuration);
            _collection = _context.GetCollection<Birthday>(COLLECTION_NAME);
        }

        public BirthdayRepository(IMongoBirthdayDbContext context)
        {
            _context = context;
            _collection = _context.GetCollection<Birthday>(COLLECTION_NAME);
        }

        public IMongoCollection<Birthday> GetCollection() =>
            _collection;

        public IEnumerable<Birthday> GetAll() =>
            _collection.Find(Builders<Birthday>.Filter.Empty).ToEnumerable();

        public long Count() =>
            _collection.CountDocuments(Builders<Birthday>.Filter.Empty);

        public Birthday GetById(string id) =>
            _collection.Find(data => data.Id == id).FirstOrDefault();

        public void Add(Birthday data) =>
            _collection.InsertOne(data);

        public void Update(Birthday data, string id) =>
            _collection.ReplaceOne(birthday => birthday.Id == id, data);

        public void Delete(string id) =>
            _collection.DeleteOne(birthday => birthday.Id == id);
    }
}
