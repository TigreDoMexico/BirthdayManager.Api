using BirthdayManager.Api.Models;
using BirthdayManager.Domain.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayManager.Api.Factory
{
    public static class BirthdayModelFactory
    {
        public static BirthdayModel ToModel(this BirthdayDTO.Get data)
        {
            var model = new BirthdayModel
            {
                Id = data.Id,
                Nome = data.Name,
                Data = data.Date
            };

            return model;
        }

        public static List<BirthdayModel> ToModel(this List<BirthdayDTO.Get> listData) =>
            listData.Select(data => data.ToModel()).ToList();

        public static BirthdayDTO.Create ToDTO(this CreateBirthdayModel model)
        {
            var dto = new BirthdayDTO.Create
            {
                Name = model.Nome,
                Date = model.Data
            };

            return dto;
        }
    }
}