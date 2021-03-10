using ElevaCase.Domain.Core.Commands;
using System.Threading.Tasks;

namespace ElevaCase.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}
