using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public delegate void GradeAddDelegate(Object sender, EventArgs args);

    public abstract class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddDelegate GradeAdded;

    }

    //    public abstract class Book : NamedObject
    //    {
    //        //public Book(string name) : base(name)
    //        { 
    //        }
    //    //public abstract void AddGrade(double grade);
    //}

    public class DiskBook : IBook
    {
        public DiskBook(string name) : base(name)
        {
        }

        string IBook.Name => throw new NotImplementedException();

        public event GradeAddDelegate GradeAdded;

        public void AddGrade(double grade)
        {
            File.AppendText(1);
        }

        public Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook : NamedObject, IBook
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            { 
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                case 'F':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
            
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
             
            }
            else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddDelegate GradeAdded;
        
        public Statistics GetStatistics() 
        {
            var result = new Statistics();
            //ComputeAverage 
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Average = 0.0;
           
            for (var index = 0; index < grades.Count; index++)
            { 
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
              };
            

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;

        }

        public List<double> grades;
        
        const string category = "Science";

        private string name;
    }
}
 