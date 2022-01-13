using System;
using BirthdayManager.Domain.DTO;
using BirthdayManager.Domain.Factory;
using Xunit;

namespace BirthdayManager.Test.Domain.Factories
{
    public class AoTransformarUmBirthdayDTO
    {
        public BirthdayDTO.Create actualData = new BirthdayDTO.Create {
          Name = "Teste",
          Date = new DateTime(2022, 01, 01)
        };

        [Fact]
        public void ParaDataDeveConverterOCampoDateParaOFormatoStringCorreto()
        {
            // Arrange
            var expectData = "2022-01-01";

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