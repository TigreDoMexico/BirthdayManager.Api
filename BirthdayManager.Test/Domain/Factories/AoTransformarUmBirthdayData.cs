using System;
using BirthdayManager.Data.Models;
using BirthdayManager.Domain.DTO;
using BirthdayManager.Domain.Factory;
using Xunit;

namespace BirthdayManager.Test.Domain.Factories
{
    public class AoTransformarUmBirthdayData
    {
        private int year = 2022;
        private int month = 5;
        private int day = 30;
        private Birthday actualData;

        public AoTransformarUmBirthdayData()
        {
            actualData = new Birthday {
                Id = "123",
                Name = "Teste",
                Date = string.Format("{0}-{1}-{2}", year, month, day)
            };
        }

        [Fact]
        public void ParaDTODeveManterOCampoIdENomeIguais()
        {
            // Act
            var transformData = actualData.ToBirthdayDTO();

            // Assert
            Assert.Equal(transformData.Id, actualData.Id);
            Assert.Equal(transformData.Name, actualData.Name);
        }

        [Fact]
        public void ParaDTODeveManterTransformarOCampoDataParaADataCorreta()
        {
            // Arrange
            var convertedDate = new DateTime(2022, 01, 01);

            // Act
            var transformData = actualData.ToBirthdayDTO();
        
            // Assert
            Assert.Equal(transformData.Date.Day, day);
            Assert.Equal(transformData.Date.Month, month);
            Assert.Equal(transformData.Date.Year, year);
        }
    }
}