using BirthdayManager.Test.Contracts;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayManager.Test.Data.Mock
{
    public class ConfigurationMock
    {
        private EnvironmentData envData;               
        private Mock<IConfigurationSection> mockConnectionString = new Mock<IConfigurationSection>();
        private Mock<IConfigurationSection> mockDatabaseName = new Mock<IConfigurationSection>();

        public Mock<IConfiguration> MockConfig { get; private set; } = new Mock<IConfiguration>();

        public string ConnectionString => envData.MongoDbConnectionString;
        public string DatabaseName => envData.MongoDbDatabase;

        public ConfigurationMock()
        {
            LoadEnvData();
            InitializeMockData();
        }

        private void InitializeMockData()
        {
            mockConnectionString.Setup(config => config.Value).Returns(envData.MongoDbConnectionString);
            mockDatabaseName.Setup(config => config.Value).Returns(envData.MongoDbDatabase);

            MockConfig.Setup(mock => mock.GetSection(It.Is<string>(value => value == "MongoSettings:ConnectionStrings")))
                .Returns(mockConnectionString.Object);

            MockConfig.Setup(mock => mock.GetSection(It.Is<string>(value => value == "MongoSettings:DatabaseName")))
                .Returns(mockDatabaseName.Object);
        }

        private void LoadEnvData()
        {
            var path = Path.Combine(Path.GetDirectoryName("../../../Data"), "Data/appsettings.json");
            var json = File.ReadAllText(path);

            envData = JsonConvert.DeserializeObject<EnvironmentData>(json);
        }



    }
}
