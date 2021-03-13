using AutoFixture;
using ElevaCase.Api.Controllers;
using ElevaCase.Application.Interfaces;
using ElevaCase.Application.ViewModel;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Take.Zendesk.Integration.Tests.Controllers
{
    public class ClassesControllerTests
    {
        private readonly Mock<IClassService> _classesService;
        private readonly Fixture _fixture = new Fixture();
        private const int genericNumber = 53;
        private const string genericString = "xpto";

        public ClassesControllerTests()
        {
            _classesService = new Mock<IClassService>();
        }

        [Fact]
        public void GetClasses_GivenAValidRequest_ShouldReturnStatus200()
        {
            MockClassList();

            var controller = new ClassesController(_classesService.Object);
            var response = controller.Get(genericNumber, genericString);

            response.Should()
                .NotBeNull()
                .And.BeOfType<OkObjectResult>();

        }

        [Fact]
        public void GetClasses_GivenAValidRequest_ShouldReturnAListItems()
        {
            MockClassList();

            var controller = new ClassesController(_classesService.Object);
            var okResult = controller.Get(genericNumber, genericString) as OkObjectResult;
            
            var items = Assert.IsAssignableFrom<IEnumerable<ClassViewModel>>(okResult.Value);
            items.Should().HaveCount(10);
        }

        private void MockClassList()
        {
            var classes = _fixture
                .Build<ClassViewModel>()
                .CreateMany(10);

            _classesService
                .Setup(p => p.SearchClasses(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(classes);
        }
    }
}
