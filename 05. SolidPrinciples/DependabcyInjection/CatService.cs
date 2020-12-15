using DependencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection
{
    public class CatService 
    {
        private readonly IDbContext database;
        private readonly IRandomProvider random;
        private readonly IDateTimeProvider today;

        public CatService(
            IDbContext database, 
            IRandomProvider random, 
            IDateTimeProvider today)
        {
            this.database = database;
            this.random = random;
            this.today = today;
        }

        public IEnumerable<CatResult> RandomCatsFromToday()
        {
            var today = this.today.Now();
            var startOfToday = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);

            var totalCats = this.random.Number(10, 50);

            var allCats = this.database
                .GetCats()
                .Where(c => c.AddedOn > startOfToday)
                .Take(totalCats)
                .Select(c => new CatResult
                {
                    Name = c.Name
                })
                .ToList();

            return allCats;
        }
    }
}
