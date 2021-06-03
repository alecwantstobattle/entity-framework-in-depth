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
            //var author = new Author() {Id = 1, Name = "Mosh Hamedani"};
            
            var context = new PlutoContext();
            //context.Authors.Attach(author);

            //var authors = context.Authors.ToList();

            //var author = context.Authors.Single(a => a.Id == 1);

            var course = new Course
            {
                Name = "New Course",
                Description = "New Description",
                FullPrice = 19.95f,
                Level = 1,
                // Author = new Author { Id = 1, Name = "Mosh Hamedani" }
                // Author = author
                AuthorId = 1
                // Author = author
            };

            context.Courses.Add(course);

            context.SaveChanges();
        }
    }
}
