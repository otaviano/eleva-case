using AutoFixture;
using ElevaCase.Domain.CommandHandlers;
using ElevaCase.Domain.Commands;
using ElevaCase.Domain.Entities;
using ElevaCase.Domain.Exceptions;
using ElevaCase.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ElevaCase.UnitTests.Domain.CommandHandlers
{
    public class SchoolCommandHandlerTests
    {
        private readonly Mock<ISchoolRepository> _schoolRepository;
        private readonly SchoolCommandHandler _schoolCommandHandler;
        private readonly Fixture _fixture = new Fixture();
        private readonly CancellationToken _cancelationToken; 
        private const string genericString = "xpto";

        public SchoolCommandHandlerTests()
        {
            _schoolRepository = new Mock<ISchoolRepository>();
            _cancelationToken = new CancellationToken();
            _schoolCommandHandler = new SchoolCommandHandler(_schoolRepository.Object);
        }

        [Fact]
        public async Task Handle_GivenAValidCreateSchoolCommand_ShouldCallCreateRepositoryAsync()
        {
            var command = new Mock<CreateSchoolCommand>(genericString, genericString);
            var school = _fixture
                .Build<School>()
                .Without(p => p.Classes)
                .Create();

            _schoolRepository.Setup(p => p.Create(It.IsAny<School>()));
            await _schoolCommandHandler.Handle(command.Object, _cancelationToken);

            _schoolRepository.Verify(x => x.Create(It.IsAny<School>()), Times.Once);
        }

        [Fact]
        public void Handle_GivenAnInvalidCreateSchoolCommand_ShouldThrow()
        {
            Assert.ThrowsAsync<InvalidCommandException>(() => _schoolCommandHandler.Handle(null, new CancellationToken()));
        }
    }
}
