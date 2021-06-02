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

            var query =
                from c in context.Courses
                where c.Level == 1 && c.AuthorId == 1
                select c;

            // Ordering
            var ordering =
                from c in context.Courses
                where c.AuthorId == 1
                orderby c.Level descending, c.Name
                select c;

            // Projection
            var projection =
                from c in context.Courses
                where c.AuthorId == 1
                orderby c.Level descending, c.Name
                select new { Name = c.Name, Author = c.Author.Name };

            // Grouping
            var grouping =
                from c in context.Courses
                group c by c.Level
                into g
                select g;

            foreach (var group in grouping)
            {
                //Console.WriteLine(group.Key);
                //foreach (var course in group)
                //{
                //    Console.WriteLine("\t{0}", course.Name);
                //}

                Console.WriteLine("{0} ({1})", group.Key, group.Count()); // Aggregate function count in Groups
            }

            // Joining
            // using Navigation Property to join in LINQ instead of using Inner Join
            var navigationProperty =
                from c in context.Courses
                select new { CourseName = c.Name, AuthorName = c.Author.Name };

            // Inner Join w/o Navigation Property
            var innerJoinWithoutNavigationProperty =
                from c in context.Courses
                join a in context.Authors on c.AuthorId equals a.Id
                select new { Course = c.Name, AuthorName = a.Name };

            // Group Join
            var groupJoin =
                from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId into g
                select new {AuthorName = a.Name, Courses = g.Count()};
            foreach (var x in groupJoin)
                Console.WriteLine("{0} ({1})", x.AuthorName, x.Courses);

            // Cross Join
            var crossJoin =
                from a in context.Authors
                from c in context.Courses
                select new {AuthorName = a.Name, CourseName = c.Name};

            foreach (var x in crossJoin)
            {
                Console.WriteLine("{0} ({1})", x.AuthorName, x.CourseName);
            }
        }
    }
}
