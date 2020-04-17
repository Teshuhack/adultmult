using AdultMult.Models;
using AdultMult.Models.Commands;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Telegram.Bot;

namespace AdultMult.Services
{
    public class BotService : IBotService
    {
        private readonly BotConfiguration _botConfiguration;
        private readonly List<Command> commands;

        public TelegramBotClient Client { get; }

        public IReadOnlyList<Command> Commands => commands.AsReadOnly();

        public BotService(IOptions<BotConfiguration> botConfiguration)
        {
            _botConfiguration = botConfiguration.Value;

            commands = new List<Command>
            {
                new TestCommand()
            };

            Client = new TelegramBotClient(_botConfiguration.BotToken);

            var hook = string.Format(_botConfiguration.WebHookUrl, "api/update");
            Client.SetWebhookAsync(hook);
        }
    }
}
