using BirthdayManager.Data.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Data.DAO
{
    internal class BirthdayRepository
    {
        private MongoBirthdayDbContext _context;

        public BirthdayRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoSettings:ConnectionStrings").ToString();
            var databaseName = configuration.GetSection("MongoSettings:DatabaseName").ToString();

            _context = new MongoBirthdayDbContext(connectionString, databaseName);
        }

    }
}
