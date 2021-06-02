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

            //var courses = context.Courses;
            //var filtered = courses.Where(c => c.Level == 1);
            //var sorted = filtered.OrderBy(c => c.Name);

            //var courses = context.Courses.Where(c => c.Level == 1).OrderBy(c => c.Name);
            //var courses = context.Courses.Where(c => c.IsBegginerCourse == true); // Unhandled Exception

            var courses = context.Courses.ToList().Where(c => c.IsBegginerCourse == true);

            foreach (var c in courses)
                Console.WriteLine(c.Name);
        }
    }
}
