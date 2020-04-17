using Hangfire;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AdultMult.Services
{
    public class JobService : IJobService
    {
        private readonly ILogger<JobService> _logger;
        private readonly IBotService _botService;

        public JobService(ILogger<JobService> logger, IBotService botService)
        {
            _logger = logger;
            _botService = botService;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public async Task RunAtTimeOf(DateTime now)
        {
            _logger.LogInformation("My Job starts...");
            // do some work
            // 191182294
            //await _botService.Client.SendTextMessageAsync(191182294, $"Test: {DateTime.Now}");
            _logger.LogInformation("My Job completed.");
        }
    }
}
