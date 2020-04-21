using AdultMult.DataProvider;
using AdultMult.Helpers;
using AdultMult.Models;
using Hangfire;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdultMult.Services
{
    public class Job : IJob
    {
        private readonly ILogger<Job> _logger;
        private readonly AdultMultContext _adultMultContext;
        private readonly IBotService _botService;
        private readonly IAdultMultService _adultMultService;
        private readonly BotConfiguration _botConfiguration;
        private const string NO_UPDATES_MESSAGE = "Обновлений нет";

        public Job(
            ILogger<Job> logger,
            AdultMultContext adultMultContext,
            IBotService botService,
            IAdultMultService adultMultService,
            IOptions<BotConfiguration> botConfiguration)
        {
            _logger = logger;
            _adultMultContext = adultMultContext;
            _botService = botService;
            _adultMultService = adultMultService;
            _botConfiguration = botConfiguration.Value;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public async Task RunAtTimeOf(DateTime now)
        {
            _logger.LogInformation("My Job starts...");
  
            await _adultMultService.ParseMultsAsync();
            var mults = _adultMultContext.Mults.Where(x => x.IsUpdated).ToList();

            if (mults.Any())
            {
                mults.ForEach(x => x.IsUpdated = default);

                await _adultMultContext.SaveChangesAsync();
                var result = AdultMultHelper.PrintMultsCollection(mults);

                await _botService.Client.SendTextMessageAsync(_botConfiguration.ChatId, result);
            }
            else
            {
                await _botService.Client.SendTextMessageAsync(_botConfiguration.ChatId, NO_UPDATES_MESSAGE);
            }

            _logger.LogInformation("My Job completed.");
        }
    }
}
