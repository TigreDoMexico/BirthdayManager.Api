using System;
using BirthdayManager.Domain.DTO;
using BirthdayManager.Domain.Factory;
using Xunit;

namespace BirthdayManager.Test.Domain.Factories
{
    public class AoTransformarUmBirthdayDTO
    {
        private int year = 2022;
        private int month = 5;
        private int day = 30;
        private BirthdayDTO.Create actualData;

        public AoTransformarUmBirthdayDTO()
        {
            actualData = new BirthdayDTO.Create {
                Name = "Teste",
                Date = new DateTime(year, month, day)
            };
        }

        [Fact]
        public void ParaDataDeveConverterOCampoDateParaOFormatoStringCorreto()
        {
            // Arrange
            var expectData = String.Format("{0}-0{1}-{2}", year, month, day);

            // Act
            var transformData = actualData.ToBirthdayData();
         
            // Assert
            Assert.IsType<string>(transformData.Date);
            Assert.Equal(transformData.Date, expectData);
        }

        [Fact]
        public void ParaDataDeveManterONomeIgualAoDTO()
        {
            // Act
            var transformData = actualData.ToBirthdayData();
         
            // Assert
            Assert.Equal(transformData.Name, actualData.Name);
        }
    }
}