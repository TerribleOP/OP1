using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dataFile = "Students.csv";
            const string answerFile = "Results.csv";
            string header = string.Format("{0,-10} |{1,-8}|{2,-8}|{3,-15}|{4,-24}|\n", "Vardas", "Pavarde", "Grupe", "Pazymiu kiekis", "Pazymiai");

            File.Delete(answerFile);

            StudentRegister Students = new StudentRegister();

            Students = InOutUtils.readStudents(dataFile);

            InOutUtils.printStudents(answerFile,header,Students);

            Students.Sort();

            InOutUtils.printAnswer(answerFile, header, Students);










        }
    }
}
