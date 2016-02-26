using System;
using System.Linq;
using GeekDinner.Core;
using GeekDinner.Infrastructure;
using Microsoft.AspNet.Mvc;

namespace GeekDinner.Controllers
{
    public class OriginalDinnersController : Controller
    {
        private readonly GeekDinnerDbContext _dbContext;

        public OriginalDinnersController(GeekDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Dinners.ToList());
        }

        public IActionResult PopulateDatabase()
        {
            _dbContext.Dinners.Add(CreateDinner("ASP.NET Core Dinner",
                "The first geek dinner on ASP.NET Core"));
            _dbContext.Dinners.Add(CreateDinner("Another ASP.NET Core Dinner",
                "The second geek dinner on ASP.NET Core"));
            _dbContext.Dinners.Add(CreateDinner("One More ASP.NET Core Dinner",
                "A geek dinner on ASP.NET Core"));
            _dbContext.SaveChanges();
            return Ok();
        }

        private Dinner CreateDinner(string title, string description)
        {
            return new Dinner()
            {
                Address = "",
                ContactPhone = "",
                Country="USA",
                Description = description,
                EventDate = DateTime.Today,
                HostedBy = "@ardalis",
                Title = title
            };
        }
    }
}
