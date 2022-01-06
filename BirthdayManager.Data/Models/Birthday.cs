using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Data.Models
{
    public class Birthday
    {
        [BsonId]
        public string Id { get; set; }
        public int Name { get; set; }
        public string Date { get; set; }
    }
}
