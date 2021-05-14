using System.IO;
using Microsoft.Extensions.Configuration;

namespace CMPTestAutomation
{
    public static class Configuration
    {
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets("58a2ea31-ee25-4e96-84d9-009f9896ea54");

            return builder.Build();
        }

        public static CmpTestConfiguration GetApplicationConfiguration()
        {
            var configuration = new CmpTestConfiguration();

            var iConfig = GetIConfigurationRoot();

            iConfig
                .GetSection("CMPTests")
                .Bind(configuration);

            return configuration;
        }
    }

    public class CmpTestConfiguration
    {
        public string AdminAccountPassword { get; set; }
        public string AuthorAccountPassword { get; set; }
        public string EditorAccountPassword { get; set; }
    }
}
