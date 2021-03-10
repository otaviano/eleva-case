using ElevaCase.Domain.Core.Commands;

namespace ElevaCase.Domain.Commands
{
    public abstract class SchoolCommand : Command
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}
