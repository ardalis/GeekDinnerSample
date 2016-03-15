using GeekDinner.ClientModels;
using GeekDinner.Controllers;
using GeekDinner.Core;
using GeekDinner.Core.Interfaces;
using Microsoft.AspNet.Mvc;
using Moq;
using Xunit;

namespace GeekDinner.Tests
{
    public class DinnersControllerAddRsvp
    {
        private readonly Mock<IDinnerRepository> _mockRepository;
        private readonly Mock<IDateTime> _mockDateTime;
        public DinnersControllerAddRsvp()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _mockDateTime = new Mock<IDateTime>();
        }

        [Fact]
        public void Returns404GivenNotMatchingDinnerId()
        {
            _mockRepository.Setup(r => r.GetById(0)).Returns((Dinner)null);
            var controller = new DinnersController(_mockRepository.Object, _mockDateTime.Object);

            var result = Assert.IsType<HttpNotFoundObjectResult>(controller.AddRsvp(new RsvpRequest()));
            Assert.Equal("Dinner not found.", (string)result.Value);
        }

        [Fact]
        public void ReturnsBadRequestGivenInvalidModelState()
        {
            var controller = new DinnersController(_mockRepository.Object, _mockDateTime.Object);
            controller.ModelState.TryAddModelError("name", "name is required");

            var result = controller.AddRsvp(new RsvpRequest()) as BadRequestObjectResult;

            Assert.NotNull(result);
        }
    }
}
