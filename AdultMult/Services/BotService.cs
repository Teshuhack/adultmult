using AdultMult.Models;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace AdultMult.Services
{
    public class BotService : IBotService
    {
        private readonly BotConfiguration _botConfiguration;

        public TelegramBotClient Client { get; }

        public BotService(IOptions<BotConfiguration> botConfiguration)
        {
            _botConfiguration = botConfiguration.Value;

            Client = new TelegramBotClient(_botConfiguration.BotToken);

            var hook = string.Format(_botConfiguration.WebHookUrl, "api/update");
            Client.SetWebhookAsync(hook);
        }
    }
}
