using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            // Partitioning
            var courses = context.Courses.Skip(10).Take(10);

            // Element Operators
            context.Courses.OrderBy(c => c.Level).FirstOrDefault(c => c.FullPrice > 100);

            context.Courses.Last();
            context.Courses.SingleOrDefault(c => c.Id == 1);

            // Quantifying
            var allAbove10Dollars = context.Courses.All(c => c.FullPrice > 10);
            context.Courses.Any(c => c.Level == 1);

            // Aggregate
            var count = context.Courses.Where(c => c.Level == 1).Count();
            context.Courses.Max(c => c.FullPrice);
            context.Courses.Min(c => c.FullPrice);
            context.Courses.Average(c => c.FullPrice);
        }
    }
}
