using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class Book
    {
        public Book( string name) 
        {
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        public void ShowStats() {
            //ComputeAverage 
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            var result = 0.0;

            foreach (var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }
            result /= grades.Count;

            Console.WriteLine($"The averege grade is {result:N1}");
            Console.WriteLine($"The max grade is {highGrade:N1}");
            Console.WriteLine($"The lowest grade is {lowGrade:N1}");

            //if (args.Length > 0)
            //{
            //    Console.WriteLine($"Hello, {args[0]} !");
            //}
            //else
            //{
            //    Console.WriteLine("Hello stainger!");
            //}
        }

        private List<double> grades;
        private string name;

    }
}
