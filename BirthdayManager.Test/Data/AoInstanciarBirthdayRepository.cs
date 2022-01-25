using BirthdayManager.Data.Context.Contract;
using BirthdayManager.Data.DAO;
using BirthdayManager.Data.Models;
using BirthdayManager.Test.Data.Mock.Contract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BirthdayManager.Test.Data
{   
    public class AoInstanciarBirthdayRepository
    {
        private Mock<IMongoBirthdayDbContext> mockContext = new Mock<IMongoBirthdayDbContext>();
        private Mock<IMongoCollection<Birthday>> mockCollection = new Mock<IMongoCollection<Birthday>>();

        public AoInstanciarBirthdayRepository()
        {


            mockCollection.Setup(collection => collection
                .CountDocuments(It.IsAny<FilterDefinition<Birthday>>(), null, default))
                    .Returns((long) 5);

            //mockCollection.Setup(collection => collection
            //    .Find(It.Is<FilterDefinition<Birthday>>(birthday => true), null))
            //        .Returns(1);

            mockContext.Setup(context => context
                .GetCollection<Birthday>(It.IsAny<string>()))
                    .Returns(mockCollection.Object);
        }

        [Fact]
        public void Deve_RetornarOValorCorretoDeDocumentos_Quando_ChamadoOMetodoDeCountDocuments()
        {
            // ARRANGE
            var repository = new BirthdayRepository(mockContext.Object);

            // ACT
            var result = repository.Count();

            // ASSERT
            Assert.Equal((long) 5, result);
        }

    }
}
