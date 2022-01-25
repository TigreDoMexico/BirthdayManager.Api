using System.Reflection;
using System.IO;
using BirthdayManager.Data.Context;
using Xunit;
using Newtonsoft.Json;
using BirthdayManager.Test.Contracts;
using BirthdayManager.Data.Models;
using BirthdayManager.Test.Data.Mock;

namespace BirthdayManager.Test.Data
{
    public class AoCriarMongoDbContext
    {
        private ConfigurationMock _config;

        public AoCriarMongoDbContext()
        {
            _config = new ConfigurationMock();
        }

        [Fact]
        public void Deve_InstanciarAsVariaveisDeAmbiente_Quando_IniciadoOsTestes()
        {
            Assert.NotNull(_config);
            Assert.False(string.IsNullOrEmpty(_config.ConnectionString));
            Assert.False(string.IsNullOrEmpty(_config.DatabaseName));
        }

        [Fact]
        public void Deve_InstanciarOBancoDeDados_Quando_ChamadoConstrutorComConnectionStringENomeDoBancoDeDados()
        {
            var context = new MongoBirthdayDbContext(_config.MockConfig.Object);
            Assert.NotNull(context.Database);
        }

        [Fact]
        public void Deve_RetornarUmaCollectionDoTipoBirthday_Quando_PassadoONomeDaCollectionEOTipoBirthday()
        {
            const string collectionName = "Birthday";

            // ACT
            var context = new MongoBirthdayDbContext(_config.MockConfig.Object);
            var collection = context.GetCollection<Birthday>(collectionName);

            Assert.NotNull(collection);
            Assert.Equal(collection.Database.DatabaseNamespace.DatabaseName, collectionName);
        }
    }
}