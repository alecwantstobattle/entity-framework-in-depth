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
            //var context = new PlutoContext();
            //IQueryable<Course> courses = context.Courses;
            //var filtered = courses.Where(c => c.Level == 1);
            //foreach (var course in filtered)
            //    Console.WriteLine(course.Name); 

            //IEnumerable<Course> x;
            //x.Where() // expects a Func

            IQueryable<Course> x;
            x.Where(c => c.Level == 1).OrderBy(c => c.Name);

        }
    }
}
