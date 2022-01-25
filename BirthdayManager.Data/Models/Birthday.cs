using MongoDB.Bson.Serialization.Attributes;

namespace BirthdayManager.Data.Models
{
    public class Birthday
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
