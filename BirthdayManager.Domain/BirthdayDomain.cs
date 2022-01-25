using BirthdayManager.Data;
using BirthdayManager.Data.DAO;
using BirthdayManager.Data.DAO.Contract;
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
        private readonly BirthdayRepository _repository;

        public BirthdayDomain(IConfiguration configuration)
        {
            _repository = new BirthdayRepository(configuration);
        }

        public BirthdayDomain(IRepository<Birthday> repository)
        {
            _repository = repository as BirthdayRepository;
        }

        #region Repository Methods

        public long CountAllBirthdays() =>
            _repository.Count();

        public List<BirthdayDTO.Get> GetAllBirthdays() =>
            _repository.GetAll().ToDTOList();

        public BirthdayDTO.Get GetBirthday(string id) =>
            _repository.GetById(id).ToBirthdayDTO();

        public void AddBirthday(BirthdayDTO.Create birthday) =>
            _repository.Add(birthday.ToBirthdayData());

        public void UpdateBirthday(string id, BirthdayDTO.Create newData) =>
            _repository.Update(newData.ToBirthdayData(), id);

        public void DeleteBirthday(string id) =>
            _repository.Delete(id);

        #endregion
    }
}
