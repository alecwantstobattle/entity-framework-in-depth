using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{
    public enum Level : Byte
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var course = new Course();
            course.Level = CourseLevel.Beginner; // 1
        }
    }
}
