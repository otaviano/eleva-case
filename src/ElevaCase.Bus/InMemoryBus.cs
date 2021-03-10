
using ElevaCase.Domain.Core.Bus;
using ElevaCase.Domain.Core.Commands;
using MediatR;
using System.Threading.Tasks;

namespace ElevaCase.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediator;

        public InMemoryBus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }
    }
}
