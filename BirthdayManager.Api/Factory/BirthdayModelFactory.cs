using BirthdayManager.Api.Models;
using BirthdayManager.Domain.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayManager.Api.Factory
{
    /// <summary>
    /// Classe respons�vel por converter dados de dentro da API para o Domain e vice-versa
    /// </summary>
    public static class BirthdayModelFactory
    {
        /// <summary>
        /// Transforma um DTO de Anivers�rio em um Model para retornar para a View
        /// </summary>
        /// <param name="data">Dados vindos do Domain em formato DTO</param>
        /// <returns>Dados convertidos em Model</returns>
        public static BirthdayModel ToModel(this BirthdayDTO.Get data)
        {
            if(data == null) return null;

            var model = new BirthdayModel
            {
                Id = data.Id,
                Nome = data.Name,
                Data = data.Date
            };

            return model;
        }

        /// <summary>
        /// Transforma uma lista de DTO de Anivers�rio em um Model para retornar para a View
        /// </summary>
        /// <param name="listData">Lista de Dados vindos do Domain em formato DTO</param>
        /// <returns>Lista de Dados convertidos em Model</returns>
        public static List<BirthdayModel> ToModel(this List<BirthdayDTO.Get> listData) =>
            listData.Select(data => data.ToModel()).ToList();

        /// <summary>
        /// Transforma os dados de Cria��o do Model em um DTO para enviar para o Domain
        /// </summary>
        /// <param name="model">Dados de Cria��o vindos do Model</param>
        /// <returns>Dados convertidos em um DTO de Cria��o</returns>
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