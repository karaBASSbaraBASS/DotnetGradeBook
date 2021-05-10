using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    { 
        static void Main(string[] args)
        {

            var book = new Book("Scott`s Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(70.1);

            var stats = book.GetStatistics();

            Console.WriteLine($"The averege grade is {stats.Average:N1}");
            Console.WriteLine($"The max grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");


            //if (args.Length > 0)
            //{
            //    Console.WriteLine($"Hello, {args[0]} !");
            //}
            //else
            //{
            //    Console.WriteLine("Hello stainger!");
            //}
        }
    }
}
