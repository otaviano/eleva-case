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
    public class SchoolsControllerTests
    {
        private readonly Mock<ISchoolService> _schoolService;
        private readonly Fixture _fixture = new Fixture();
        private const string genericString = "xpto";

        public SchoolsControllerTests()
        {
            _schoolService = new Mock<ISchoolService>();
        }

        [Fact]
        public void GetSchools_GivenAValidRequest_ShouldReturnStatus200()
        {
            MockSchoolList();

            var controller = new SchoolsController(_schoolService.Object);
            var response = controller.Get(genericString);

            response.Should()
                .NotBeNull()
                .And.BeOfType<OkObjectResult>();

        }

        [Fact]
        public void GetSchools_GivenAValidRequest_ShouldReturnAListItems()
        {
            MockSchoolList();

            var controller = new SchoolsController(_schoolService.Object);
            var okResult = controller.Get(genericString) as OkObjectResult;
            
            var items = Assert.IsAssignableFrom<IEnumerable<SchoolViewModel>>(okResult.Value);
            items.Should().HaveCount(10);
        }

        private void MockSchoolList()
        {
            var schools = _fixture
                .Build<SchoolViewModel>()
                .CreateMany(10);

            _schoolService
                .Setup(p => p.SearchSchools(It.IsAny<string>()))
                .Returns(schools);
        }
    }
}
