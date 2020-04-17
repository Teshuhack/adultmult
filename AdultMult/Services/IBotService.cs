using AdultMult.Models.Commands;
using System.Collections.Generic;
using Telegram.Bot;

namespace AdultMult.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }

        IReadOnlyList<Command> Commands { get; }
    }
}
