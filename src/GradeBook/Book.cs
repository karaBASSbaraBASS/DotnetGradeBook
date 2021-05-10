using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Book
    {
        public Book( string name) 
        {
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        public Statistics GetStatistics() 
        {
            var result = new Statistics();
            //ComputeAverage 
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Average = 0.0;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;

        }

        private List<double> grades;

    }
}
