using Telegram.Bot;

namespace AdultMult.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}
