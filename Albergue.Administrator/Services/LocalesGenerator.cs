﻿using Albergue.Administrator.SQLite.Database.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue.Administrator.Services
{
    public class LocalesGenerator : ILocalesGenerator
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemRepository;

        private readonly ILogger<LocalesGenerator> _logger;

        public LocalesGenerator(
            ILogger<LocalesGenerator> logger,
            IConfiguration configuration,
            ILanguageRepository languageRepository,
            ICategoryRepository categoryRepository,
            IItemRepository itemRepository)
        {
            _logger = logger;
            Configuration = configuration;
            _languageRepository = languageRepository;
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
        }

        public IConfiguration Configuration { get; }

        public async Task GenerateAsync()
        {
            try
            {
                var destinationFolder = Configuration.GetValue<string>("LocalesDir");
                var defaultNS = Configuration.GetValue<string>("LocalesNS");

                var languages = await _languageRepository.GetAllAsync();
                var categories = await _categoryRepository.GetAllAsync();
                var items = await _itemRepository.GetAllAsync();

                languages.AsParallel().ForAll(async (lng) =>
                {
                    var translations = new Dictionary<string, object>();
                    var categoryTranslations = categories.Select(
                        p => new KeyValuePair<string, object>(
                            p.KeyName,
                            p.TranslatableDetails.FirstOrDefault(pp => pp.LanguageId == lng.Id) != null ? p.TranslatableDetails.FirstOrDefault(pp => pp.LanguageId == lng.Id).Name : "Not found")
                    );

                    foreach (var translation in categoryTranslations)
                    {
                        translations.TryAdd(translation.Key, translation.Value);
                    }

                    var itemTranslations = new Dictionary<string, object>();
                    foreach (var item in items)
                    {
                        var inner = new Dictionary<string, string>();
                        inner.TryAdd("description", item.TranslatableDetails.FirstOrDefault(pp => pp.LanguageId == lng.Id) != null ? item.TranslatableDetails.FirstOrDefault(pp => pp.LanguageId == lng.Id).Description : "Not found");
                        inner.TryAdd("shortDescription", item.TranslatableDetails.FirstOrDefault(pp => pp.LanguageId == lng.Id) != null ? item.TranslatableDetails.FirstOrDefault(pp => pp.LanguageId == lng.Id).ShortDescription : "Not found");
                        inner.TryAdd("name", item.TranslatableDetails.FirstOrDefault(pp => pp.LanguageId == lng.Id) != null ? item.TranslatableDetails.FirstOrDefault(pp => pp.LanguageId == lng.Id).Name : "Not found");

                        itemTranslations.TryAdd(
                            item.Id,
                            inner);
                    }

                    foreach (var translation in itemTranslations)
                    {
                        translations.TryAdd(translation.Key, translation.Value);
                    }

                    CreateLanguageDirectory(lng, destinationFolder);

                    await SaveAsync(translations, destinationFolder + "/" + lng.Alpha2Code.ToLowerInvariant() + "/" + defaultNS + ".json");
                });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private static void CreateLanguageDirectory(Model.Language lng, string destinationFolder)
        {
            var path = destinationFolder + "/" + lng.Alpha2Code.ToLowerInvariant();
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            Directory.CreateDirectory(path);
        }

        private Task SaveAsync(Dictionary<string, object> input, string path)
        {
            try
            {
                var serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter(path))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw) { Formatting = Formatting.Indented })
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