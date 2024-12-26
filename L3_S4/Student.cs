using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _3._4
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudyGroup { get; set; }
        public int GradesCount { get; set; }
        public int[] grades { get; set; }

        public double average { get; set; }

        public Student(string firstName, string lastName, string studyGroup, int gradesCount, int[] grades)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StudyGroup = studyGroup;
            this.GradesCount = gradesCount;
            this.grades = grades;
            this.average = getAverage();
        }

        public double getAverage()
        {
            double sum = 0;
            for (int i = 0; i < GradesCount; i++)
            {
                sum += grades[i];
            }
            return sum/GradesCount;
        }

        public override string ToString()
        {
            string gradeString = string.Join(" | ", grades);
            string line = string.Format(
                "|{0,-10}|" +
                "{1,-8}|" +
                "{2,-8}|" +
                "{3,-15}|" +   
                "{4}|",       
                FirstName,
                LastName,
                StudyGroup,
                GradesCount,
                gradeString);
            return line + "\n";
        }

        public int CompareTo(Student other)
        {
            int comparison = this.average.CompareTo(other.average);

            if (comparison != 0)
            {
                return comparison;
            }
            else
            {
                return other.LastName.CompareTo(this.LastName);
            }
        }

    }
}
