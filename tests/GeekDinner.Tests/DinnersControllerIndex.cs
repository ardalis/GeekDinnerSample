using System.Collections.Generic;
using System.Linq;
using GeekDinner.Controllers;
using GeekDinner.Core;
using GeekDinner.Core.Interfaces;
using Microsoft.AspNet.Mvc;
using Moq;
using Xunit;

namespace GeekDinner.Tests
{
    public class DinnersControllerIndex
    {
        private readonly Mock<IDinnerRepository> _mockRepository;
        public DinnersControllerIndex()
        {
            _mockRepository = new Mock<IDinnerRepository>();
        }

        private List<Dinner> GetTestDinnerCollection()
        {
            return new List<Dinner>()
            {
                new Dinner() {Title = "Test Dinner 1" },
                new Dinner() {Title = "Test Dinner 2" }
            };
        }

        [Fact]
        public void ReturnsDinnersInViewModel()
        {
            _mockRepository.Setup(r => r.List()).Returns(GetTestDinnerCollection());
            var controller = new DinnersController(_mockRepository.Object, null);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<List<Dinner>>(viewResult.ViewData.Model);
            Assert.Equal("Test Dinner 1", viewModel.First().Title);
            Assert.Equal(2, viewModel.Count);
        }
    }
}
