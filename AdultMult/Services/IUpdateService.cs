using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace AdultMult.Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
