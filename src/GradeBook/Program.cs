using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    { 
        static void Main(string[] args)
        {

            var book = new InMemoryBook("Scott`s Grade Book");
            //book.AddGrade(89.1);
            //book.AddGrade(90.5);
            //book.AddGrade(70.1);
            book.GradeAdded += OnGradeAdded;

            var done = false;
            done = EnterGrades(book, done);

            var stats = book.GetStatistics();
            //book.Name = "";

            Console.WriteLine($"For the book named \"{book.Name}\"");
            Console.WriteLine($"The averege grade is {stats.Average:N1}");
            Console.WriteLine($"The max grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The average leter grade is {stats.Letter}");



        }

        private static bool EnterGrades(IBook book, bool done)
        {
            while (!done)
            {
                Console.WriteLine("Enter you grades to calculate the average, and press enter.");
                Console.WriteLine("Press the (q) key to quit: \n");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    continue;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }

            return done;
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
