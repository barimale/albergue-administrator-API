using Albergue.Administrator.Model;
using Albergue.Administrator.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PubSub;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Albergue.Administrator.HostedServices
{
    public class LocalesHostedService : IHostedService
    {
        private readonly ILocalesGenerator _generator;
        private readonly ILogger<LocalesHostedService> _logger;
        private readonly Hub _hub;

        public LocalesHostedService()
        {
            _hub = Hub.Default;
        }

        public LocalesHostedService(
            ILogger<LocalesHostedService> logger,
            IServiceProvider serviceProvider)
            : this()
        {
            _logger = logger;
            _generator = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ILocalesGenerator>();
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Locales Hosted Service running.");

            _hub.Subscribe<ShopItem>(async (item) =>
            {
                await DoWorkAsync();
            });

            _hub.Subscribe<Category>(async (item) =>
            {
                await DoWorkAsync();
            });

            _hub.Subscribe<Language>(async (item) =>
            {
                await DoWorkAsync();
            });

            return Task.CompletedTask;
        }

        private async Task DoWorkAsync(object state = null)
        {
            try
            {
                _logger.LogInformation(
                    "Locales creation in progress. ");

                await _generator.GenerateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Locales Hosted Service is stopping.");

            return Task.CompletedTask;
        }
    }
}
