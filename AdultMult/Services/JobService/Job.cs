using AdultMult.DataProvider;
using AdultMult.Helpers;
using Hangfire;
using Microsoft.Extensions.Logging;
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

        public Job(
            ILogger<Job> logger,
            AdultMultContext adultMultContext,
            IBotService botService,
            IAdultMultService adultMultService)
        {
            _logger = logger;
            _adultMultContext = adultMultContext;
            _botService = botService;
            _adultMultService = adultMultService;
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

            mults.ForEach(x => x.IsUpdated = default);

            await _adultMultContext.SaveChangesAsync();
            var result = AdultMultHelper.PrintMultsCollection(mults);

            await _botService.Client.SendTextMessageAsync(191182294, result);

            _logger.LogInformation("My Job completed.");
        }
    }
}
