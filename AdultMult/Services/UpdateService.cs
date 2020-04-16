using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AdultMult.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ILogger<UpdateService> _logger;

        public UpdateService(IBotService botService, ILogger<UpdateService> logger)
        {
            _botService = botService;
            _logger = logger;
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
            {
                return;
            }

            var message = update.Message;

            _logger.LogInformation("Received message from {0}", message.Chat.Id);

            switch (message.Type)
            {
                case MessageType.Text:
                    await _botService.Client.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;
            }
        }
    }
}
