using System.Collections.Generic;
using System.Linq;
using GeekDinner.Core;
using GeekDinner.Core.Interfaces;
using Microsoft.Data.Entity;

namespace GeekDinner.Infrastructure
{
    public class DinnerRepository : IDinnerRepository
    {
        private readonly GeekDinnerDbContext _dbContext;
        public DinnerRepository(GeekDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Dinner> List()
        {
            return _dbContext.Dinners;
        }

        public Dinner GetById(int id)
        {
            return _dbContext.Dinners.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Dinner dinner)
        {
            _dbContext.Entry(dinner).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
