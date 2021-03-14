using System.Threading;
using System.Threading.Tasks;
using ElevaCase.Domain.Commands;
using ElevaCase.Domain.Entities;
using ElevaCase.Domain.Exceptions;
using ElevaCase.Domain.Interfaces;
using MediatR;

namespace ElevaCase.Domain.CommandHandlers
{
    public class ClassCommandHandler : IRequestHandler<CreateClassCommand, bool>
    {
        private readonly IClassRepository classRepository;

        public ClassCommandHandler(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public Task<bool> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            // TODO : Extract to base or validations
            if (request == null)
            {
                throw new InvalidCommandException();
            }

            var @class = new @Class 
            { 
                Id = 0,
                SchoolId = request.SchoolId,
                Name = request.Name,
                Description = request.Description
            };

            classRepository.Create(@class);

            return Task.FromResult(true);
        }
    }
}
