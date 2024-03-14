namespace Enums
{
    internal class Program
    {
        public class Student
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Enums!");

            WeekDay day = WeekDay.Monday;//כך משתמשים ב-enum

            Course course = new Course();
            Course courseCSharp = new Course() {CourseName="C#" };
            courseCSharp.day = WeekDay.Tuesday | WeekDay.Thursday;

            Console.WriteLine(courseCSharp.day );
            Console.WriteLine((int)courseCSharp.day );


            Console.ReadLine();
        }
    }

    public class Course
    {
        int courseId;
        public string CourseName { get; set; }
        public  WeekDay day = WeekDay.Monday;
    }
 }