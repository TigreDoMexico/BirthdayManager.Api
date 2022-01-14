using BirthdayManager.Data;
using BirthdayManager.Data.Models;
using BirthdayManager.Domain.DTO;
using BirthdayManager.Domain.Factory;
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

        public BirthdayDomain(ContextDomain domain)
        {
            var db = domain.GetDatabase("Birthdays");
            _birthdays = db.GetCollection<Birthday>("Birthday");
        }

        public long CountAllBirthdays() => 
            _birthdays.CountDocuments(birthday => true);
        
        public List<BirthdayDTO.Get> GetAllBirthdays() =>
            _birthdays.Find(birthday => true)
            .ToEnumerable().ToDTOList();

        public BirthdayDTO.Get GetBirthday(string id) =>
            _birthdays.Find(birthday => birthday.Id == id).FirstOrDefault().ToBirthdayDTO();

        public void AddBirthday(BirthdayDTO.Create birthday) =>        
            _birthdays.InsertOne(birthday.ToBirthdayData());
        
        public void UpdateBirthday(string id, BirthdayDTO.Create newData) =>
            _birthdays.ReplaceOne(birthday => birthday.Id == id, newData.ToBirthdayData());

        public void DeleteBirthday(string id) =>
            _birthdays.DeleteOne(birthday => birthday.Id == id);
    }
}
