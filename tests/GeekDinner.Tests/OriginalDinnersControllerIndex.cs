using System.Collections.Generic;
using System.Linq;
using GeekDinner.Controllers;
using GeekDinner.Core;
using GeekDinner.Infrastructure;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Xunit;

namespace GeekDinner.Tests
{
    public class OriginalDinnersControllerIndex
    {
        private readonly GeekDinnerDbContext _dbContext;
        public OriginalDinnersControllerIndex()
        {
            var optionsBuilder = new DbContextOptionsBuilder<GeekDinnerDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new GeekDinnerDbContext(optionsBuilder.Options);

            // add sample data
            _dbContext.Dinners.Add(new Dinner() { Title = "Title 1" });
            _dbContext.Dinners.Add(new Dinner() { Title = "Title 2" });
            _dbContext.Dinners.Add(new Dinner() { Title = "Title 3" });
            _dbContext.SaveChanges();
        }

        [Fact]
        public void ReturnsDinnersInViewModel()
        {
            var controller = new OriginalDinnersController(_dbContext);

            var result = controller.Index() as ViewResult;
            var viewModel = (result.ViewData.Model as IEnumerable<Dinner>).ToList();

            Assert.Equal(1, viewModel.Count(d => d.Title == "Title 1"));
            Assert.Equal(3, viewModel.Count);
        }
    }
}
