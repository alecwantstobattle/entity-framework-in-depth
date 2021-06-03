using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            var course = context.Courses.Find(4); // Single(c => c.Id == 4)
            course.Name = "New Name";
            course.AuthorId = 2;

            context.SaveChanges();
        }
    }
}
