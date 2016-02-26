using System.Collections.Generic;

namespace GeekDinner.Core.Interfaces
{
    public interface IDinnerRepository
    {
        IEnumerable<Dinner> List();
        Dinner GetById(int id);
        void Update(Dinner dinner);
    }
}
