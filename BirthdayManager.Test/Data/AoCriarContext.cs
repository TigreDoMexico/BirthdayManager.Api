using System.Reflection;
using System.IO;
using BirthdayManager.Data;
using Xunit;
using Newtonsoft.Json;
using BirthdayManager.Test.Contracts;

namespace BirthdayManager.Test.Data
{
    public class AoCriarContext
    {
        private EnvironmentData _config;

        public AoCriarContext()
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
        }

        [Fact]
        public void PassandoConnectionStringDoMongoDbDeveInstanciarContext()
        {
            MongoDbContext context = new MongoDbContext(_config.MongoDbConnectionString);
            Assert.NotNull(context.Database);
        }
    }
}