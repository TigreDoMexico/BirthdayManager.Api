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

        public BirthdayDomain(ContextDomain domain)
        {
            var db = domain.GetDatabase("BirthdayManagerDb");
            _birthdays = db.GetCollection<Birthday>("Birthday");
        }

        public List<Birthday> GetAllBirthdays() => _birthdays.Find(book => true).ToList();

        public void AddBirthdayToList()
        {

        }

        // public Book Get(string id) =>
        //     _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        // public Book Create(Book book)
        // {
        //     _books.InsertOne(book);
        //     return book;
        // }

        // public void Update(string id, Book bookIn) =>
        //     _books.ReplaceOne(book => book.Id == id, bookIn);

        // public void Remove(Book bookIn) =>
        //     _books.DeleteOne(book => book.Id == bookIn.Id);

        // public void Remove(string id) => 
        //     _books.DeleteOne(book => book.Id == id);
    }
}
