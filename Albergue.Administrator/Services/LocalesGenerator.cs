using Albergue.Administrator.SQLite.Database.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Albergue.Administrator.Services
{
    public class LocalesGenerator : ILocalesGenerator
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly ICategoryRepository _catgoryRepository;
        private readonly IItemRepository _itemRepository;

        private readonly ILogger<LocalesGenerator> _logger;

        public LocalesGenerator(
            ILogger<LocalesGenerator> logger,
            IConfiguration configuration,
            ILanguageRepository languageRepository,
            ICategoryRepository catgoryRepository,
            IItemRepository itemRepository)
        {
            _logger = logger;
            Configuration = configuration;
            _languageRepository = languageRepository;
            _catgoryRepository = catgoryRepository;
            _itemRepository = itemRepository;
        }

        public IConfiguration Configuration { get; }

        public async Task GenerateAsync()
        {
            try
            {
                var destinationFolder = Configuration.GetValue<string>("LocalesDir");
                var languages = await _languageRepository.GetAllAsync();
                var alphaCodes = languages.Select(p => p.Alpha2Code);

                alphaCodes.AsParallel().ForAll(async (languageName) =>
                {
                    var translations = new Dictionary<string, string>
                    {
                        { "key", "value" }
                    };

                    await SaveAsync(translations, destinationFolder + "/" + languageName + ".json");
                });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private Task SaveAsync(Dictionary<string,string> input, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(input, Formatting.Indented);
                var serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter(path))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, input);
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}