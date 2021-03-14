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
    public class ClassesCommandHandlerTests
    {
        private readonly Mock<IClassRepository> _classRepository;
        private readonly ClassCommandHandler _classCommandHandler;
        private readonly Fixture _fixture = new Fixture();
        private readonly CancellationToken _cancelationToken; 
        private const int genericNumber = 53;
        private const string genericString = "xpto";

        public ClassesCommandHandlerTests()
        {
            _classRepository = new Mock<IClassRepository>();
            _cancelationToken = new CancellationToken();
            _classCommandHandler = new ClassCommandHandler(_classRepository.Object);
        }

        [Fact]
        public async Task Handle_GivenAValidCreateClassCommand_ShouldCallCreateRepositoryAsync()
        {
            var command = new Mock<CreateClassCommand>(genericNumber, genericString, genericString);
            var @class = _fixture
                .Build<Class>()
                .Without(p => p.School)
                .Create();

            _classRepository.Setup(p => p.Create(It.IsAny<@Class>()));
            await _classCommandHandler.Handle(command.Object, _cancelationToken);

            _classRepository.Verify(x => x.Create(It.IsAny<@Class>()), Times.Once);
        }

        [Fact]
        public void Handle_GivenAnInvalidCreateClassCommand_ShouldThrow()
        {
            Assert.ThrowsAsync<InvalidCommandException>(() => _classCommandHandler.Handle(null, new CancellationToken()));
        }
    }
}
