using BirthdayManager.Data.Context.Contract;
using BirthdayManager.Data.DAO;
using BirthdayManager.Data.Models;
using BirthdayManager.Test.Data.Mock;
using BirthdayManager.Test.Data.Mock.Contract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BirthdayManager.Test.Data
{   
    public class AoInstanciarBirthdayRepository
    {
        private Mock<IMongoBirthdayDbContext> mockContext = new Mock<IMongoBirthdayDbContext>();
        private BirthdayCollectionMock mockBirthdayCollection = new BirthdayCollectionMock();

        [Fact]
        public void Deve_RetornarOTotalCorretoDeAniversarios_Quando_ChamadoOMetodoCount()
        {
            // ARRANGE
            mockBirthdayCollection.SetupCountDocuments();

            mockContext.Setup(context => context
                .GetCollection<Birthday>(It.IsAny<string>()))
                    .Returns(mockBirthdayCollection.Mock.Object);

            var repository = new BirthdayRepository(mockContext.Object);

            // ACT
            var result = repository.Count();

            // ASSERT
            Assert.Equal((long) mockBirthdayCollection.FakeData.Count(), result);
        }

        [Fact]
        public void Deve_RetornarUmaListaDeAniversarios_Quando_ChamadoOMetodoGetAll()
        {
            // ARRANGE
            mockBirthdayCollection.SetupFind();

            mockContext.Setup(context => context
                .GetCollection<Birthday>(It.IsAny<string>()))
                    .Returns(mockBirthdayCollection.Mock.Object);

            var repository = new BirthdayRepository(mockContext.Object);

            // ACT
            var result = repository.GetAll().ToList();

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(mockBirthdayCollection.FakeData.Count(), result.Count());
            Assert.Equal(mockBirthdayCollection.FakeData.FirstOrDefault().Id, result.FirstOrDefault().Id);
        }

    }
}
