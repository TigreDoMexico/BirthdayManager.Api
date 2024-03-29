﻿using BirthdayManager.Data.Context;
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
    public class BirthdayRepository
    {
        private MongoBirthdayDbContext _context;
        private IMongoCollection<Birthday> _collection;

        public BirthdayRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoSettings:ConnectionStrings").Value;
            var databaseName = configuration.GetSection("MongoSettings:DatabaseName").Value;

            _context = new MongoBirthdayDbContext(connectionString, databaseName);
            _collection = _context.GetCollection<Birthday>("Birthday");
        }

        public IMongoCollection<Birthday> GetCollection() =>
            _collection;

        public IEnumerable<Birthday> GetAll() =>
            _collection.Find(data => true).ToEnumerable();

        public long Count() =>
            _collection.CountDocuments(birthday => true);

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
