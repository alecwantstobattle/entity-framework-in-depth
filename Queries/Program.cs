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

            // Filter
            //var courses = context.Courses.Where(c => c.Level == 1);

            // Ordering
            var ordering = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level);

            // Projection
            var projection = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .Select(c => new {CourseName = c.Name, AuthorName = c.Author.Name});

            // Projecting to non anonymous object
            var tags = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                //.Select(c => c.Tags); 
                .SelectMany(c => c.Tags); // For flat list of Tags

            //foreach (var c in courses) // Nested Tags
            //{
            //    foreach (var tag in c)
            //    {
            //        Console.WriteLine(tag.Name);
            //    }
            //}

            foreach (var t in tags)
            {
                Console.WriteLine(t.Name);
            }

            // Distinct
            var distinct = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags)
                .Distinct();

            // Grouping
            var groups = context.Courses.GroupBy(c => c.Level);

            foreach (var group in groups)
            {
                Console.WriteLine("Key: " + group.Key);

                foreach (var course in group)
                    Console.WriteLine("\t" + course.Name);
            }

            // Joining
            var innerJoin = context.Courses.Join(context.Authors, 
                c => c.AuthorId, 
                a => a.Id, 
                (course, author) => new
                    {
                        CourseName = course.Name,
                        AuthorName = author.Name
                    });

            var groupJoin = context.Authors.GroupJoin(context.Courses, a => a.Id, c => c.Id, (author, courses) => new
            {
                AuthorName = author,
                Courses = courses.Count()
            });

            var crossJoin = context.Authors.SelectMany(a => context.Courses, (author, course) => new
            {
                AuthorName = author.Name,
                CourseName = course.Name
            });
        }
    }
}
