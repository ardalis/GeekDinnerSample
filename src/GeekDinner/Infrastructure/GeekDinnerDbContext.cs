using System;
using GeekDinner.Core;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace GeekDinner.Infrastructure
{
    public class GeekDinnerDbContext :DbContext
    {
        public GeekDinnerDbContext(DbContextOptions options) :base(options)
        {
        }
        public DbSet<Dinner> Dinners { get; set; } 
    }
}
