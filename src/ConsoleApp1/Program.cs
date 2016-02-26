using System;
using System.Collections.Generic;
using GeekDinner;
using GeekDinner.Controllers;
using GeekDinner.Core;
using GeekDinner.Infrastructure;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(Startup.ConnectionString);
            var dbContext = new GeekDinnerDbContext(optionsBuilder.Options);
            var controller = new OriginalDinnersController(dbContext);
            var result = ((ViewResult) controller.Index()).ViewData.Model as IEnumerable<Dinner>;
            foreach (var dinner in result)
            {
                Console.WriteLine($"{dinner.Title} - {dinner.Description}");
            }
        }
    }
}
