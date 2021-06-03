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

            //var course = context.Courses.Find(6);
            //context.Courses.Remove(course);

            // Cascade Delete Off

            var author = context.Authors.Include(a => a.Courses).Single(a => a.Id == 2);
            context.Courses.RemoveRange(author.Courses); 
            context.Authors.Remove(author);

            context.SaveChanges();
        }
    }
}
