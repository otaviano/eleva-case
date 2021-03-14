using System.Threading;
using System.Threading.Tasks;
using ElevaCase.Domain.Commands;
using ElevaCase.Domain.Entities;
using ElevaCase.Domain.Exceptions;
using ElevaCase.Domain.Interfaces;
using MediatR;

namespace ElevaCase.Domain.CommandHandlers
{
    public class SchoolCommandHandler : IRequestHandler<CreateSchoolCommand, bool>
    {
        private readonly ISchoolRepository schoolRepository;

        public SchoolCommandHandler(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public Task<bool> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            // TODO : Extract to base or validations
            if (request == null)
            {
                throw new InvalidCommandException();
            }

            var School = new School
            { 
                Name = request.Name,
                Description = request.Description
            };

            schoolRepository.Create(School);

            return Task.FromResult(true);
        }
    }
}
