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

            var course = context.Courses.Single(c => c.Id == 2);

            foreach (var tag in course.Tags)
                Console.WriteLine(tag.Name);
        }
    }
}
