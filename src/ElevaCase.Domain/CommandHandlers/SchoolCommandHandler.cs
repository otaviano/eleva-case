using System.Threading;
using System.Threading.Tasks;
using ElevaCase.Domain.Commands;
using ElevaCase.Domain.Entities;
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
            var School = new School
            { 
                Name = request.Name,
                Description = request.Description
            };

            schoolRepository.Add(School);

            return Task.FromResult(true);
        }
    }
}
