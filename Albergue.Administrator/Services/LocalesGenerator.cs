using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Albergue.Administrator.Services
{
    public class LocalesGenerator : ILocalesGenerator
    {
        private readonly ILogger<LocalesGenerator> _logger;

        public LocalesGenerator(ILogger<LocalesGenerator> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task GenerateAsync()
        {
            try
            {
                var start = Configuration.GetValue<string>("LocalesDir");

                var translations = new Dictionary<string, string>
                {
                    { "key", "value" }
                };

                string json = JsonConvert.SerializeObject(translations, Formatting.Indented);
                var serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter(start + "/" + "pt.json"))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, translations);
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}