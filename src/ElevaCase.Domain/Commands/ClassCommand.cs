using ElevaCase.Domain.Core.Commands;

namespace ElevaCase.Domain.Commands
{
    public abstract class ClassCommand : Command
    {
        public int SchoolId { get; protected set; }

        public string Name { get; protected set; }


        public string Description { get; protected set; }
    }
}
