using BirthdayManager.Data;
using BirthdayManager.Data.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Domain
{
    public class BirthdayDomain
    {
        private readonly IMongoCollection<Birthday> _birthdays;

        public BirthdayDomain(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var context = new MongoDbContext(connectionString);

            var db = context.Database.GetDatabase("BirthdayManagerDb");
            _birthdays = db.GetCollection<Birthday>("Birthday");
        }

        public List<Birthday> Get() => _birthdays.Find(book => true).ToList();
    }
}
