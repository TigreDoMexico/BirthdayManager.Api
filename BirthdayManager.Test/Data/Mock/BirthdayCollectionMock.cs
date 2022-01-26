using BirthdayManager.Data.Models;
using BirthdayManager.Test.Data.Mock.Contract;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Test.Data.Mock
{
    public class BirthdayCollectionMock
    {
        public IEnumerable<Birthday> FakeData { get; private set; } = new List<Birthday>
        {
            new Birthday()
            {
                Id = "1",
                Name = "Aniversário 1",
                Date = "12/10/2022"                
            },
            new Birthday()
            {
                Id = "2",
                Name = "Aniversário 2",
                Date = "13/10/2022"
            },
        };

        public Mock<IMockMongoCollection<Birthday>> Mock { get; private set; } = new Mock<IMockMongoCollection<Birthday>>();

        public void SetupFind()
        {
            var asyncCursor = new Mock<IAsyncCursor<Birthday>>();

            asyncCursor.SetupSequence(_async => _async.MoveNext(default)).Returns(true).Returns(false);
            asyncCursor.SetupGet(_async => _async.Current).Returns(FakeData);

            var resultMock = new Mock<IFindFluent<Birthday, Birthday>>();
            resultMock.Setup(fluent => fluent.ToCursor(default)).Returns(asyncCursor.Object);

            Mock.Setup(collection => collection
                .Find(It.Is<FilterDefinition<Birthday>>(a => a == Builders<Birthday>.Filter.Empty), null))
                    .Returns(resultMock.Object);
        }

        public void SetupCountDocuments()
        {
            Mock.Setup(collection => collection
                .CountDocuments(It.IsAny<FilterDefinition<Birthday>>(), null, default))
                    .Returns((long) FakeData.Count());


        }

    }
}
