using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3._4
{
    class InOutUtils
    {
        public static StudentRegister readStudents(string filename)
        {
            StudentRegister studentRegister = new StudentRegister();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            studentRegister.facultyname = lines[0];
            for (int i=1; i<lines.Length;i++)
            {
                string line = lines[i];
                string[] values = line.Split(';');
                string name=values[0];
                string lastname=values[1];
                string group=values[2];
                int amount = int.Parse(values[3]);
                int[] grades = new int[amount];
                for (int y = 0; y < amount; y++)
                {
                    grades[y] = int.Parse(values[4+y]);
                }

                Student student = new Student(name,lastname,group,amount,grades); 

                if(!studentRegister.Contains(student))
                {
                    studentRegister.Add(student);
                }
            }
            return studentRegister;
        }

        public static void printDashes(string filename)
        {
            File.AppendAllText(filename, new string('-', 71) + '\n');
        }

        public static void printStudents(string filename, string header, StudentRegister register)
        {

            File.AppendAllText(filename, "Pradiniai Duomenys:\n");
            printDashes(filename);
            string deparment = string.Format("{0}{1,48}\n",register.facultyname, "|");
            File.AppendAllText(filename, deparment);
            
            printDashes(filename);
            File.AppendAllText(filename, header);
            printDashes(filename);

            for (int i = 0;i<register.Count();i++)
            {
                Student temp = register.Get(i);
                File.AppendAllText(filename, temp.ToString());
            }
            printDashes(filename);
        }

        public static void printAnswer(string filename, string header, StudentRegister register)
        {

            File.AppendAllText(filename, "Surikiuotas sarasas pagal vidurki mazejanciai, ir abeceles tvarka \n");
            printDashes(filename);
            string deparment = string.Format("{0}{1,48}\n", register.facultyname, "|");
            File.AppendAllText(filename, deparment);

            printDashes(filename);
            File.AppendAllText(filename, header);
            printDashes(filename);

            for (int i = 0; i < register.Count(); i++)
            {
                Student temp = register.Get(i);
                File.AppendAllText(filename, temp.ToString());
            }
            printDashes(filename);
        }

    }
}
