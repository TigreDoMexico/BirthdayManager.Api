using System.Reflection;
using System.IO;
using BirthdayManager.Data.Context;
using Xunit;
using Newtonsoft.Json;
using BirthdayManager.Test.Contracts;

namespace BirthdayManager.Test.Data
{
    public class AoCriarMongoDbContext
    {
        private EnvironmentData _config;

        public AoCriarMongoDbContext()
        {
            var path = Path.Combine(Path.GetDirectoryName("../../../Data"), "Data/appsettings.json");
            var json = File.ReadAllText(path);
            _config = JsonConvert.DeserializeObject<EnvironmentData>(json);
        }
        
        [Fact]
        public void DeveInstanciarAsVariaveisDeAmbiente()
        {
            Assert.NotNull(_config);
            Assert.False(string.IsNullOrEmpty(_config.MongoDbConnectionString));
            Assert.False(string.IsNullOrEmpty(_config.MongoDbDatabase));
        }

        [Fact]
        public void PassandoConnectionStringDeveInstanciarOBancoDeDados()
        {
            var context = new MongoBirthdayDbContext(_config.MongoDbConnectionString, _config.MongoDbDatabase);
            Assert.NotNull(context.Database);
        }
    }
}