using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Data.DAO.Contract
{
    public interface IRepository<T> where T : class
    {
        IMongoCollection<T> GetCollection();

        public IEnumerable<T> GetAll();

        public T GetById(string id);

        public void Add(T data);

        public void Update(T data, string id);

        public void Delete(string id);

    }
}
