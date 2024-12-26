using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L3_U3_5
{
    class InOutUtils
    {
        /// <summary>
        /// reads initial data
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static QuestionRegister ReadQuestions(string filename)
        {
            QuestionRegister questionRegister = new QuestionRegister();
            string[] lines = File.ReadAllLines(filename);
            questionRegister.studentAssosiationName = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] values = line.Split(';');
                string theme = values[0];
                int difficulty = int.Parse(values[1]);
                string author = values[2];
                string task = values[3];
                string[] answers = { values[4], values[5], values[6], values[7] };
                int correctAnswer = int.Parse(values[8]);
                int points = int.Parse(values[9]);

                Question question = new Question(theme, difficulty, author, task, answers, correctAnswer, points);
                if (!questionRegister.Contains(question))
                {
                    questionRegister.Add(question);
                }  
            }
            return questionRegister;
        }
        /// <summary>
        /// prints initial data
        /// </summary>
        /// <param name="register"></param>
        /// <param name="filename"></param>
        public static void printInitialData(QuestionRegister register, string filename)
        {

            File.AppendAllText(filename, new string('-', 174) + '\n');
            string department = string.Format("{0,-173}|\n", register.studentAssosiationName);
            File.AppendAllText(filename, department);
            File.AppendAllText(filename, new string('-', 174) + '\n');

            string header = String.Format("|{0,-10}|{1,-8}|{2,-16}|{3,-5}|{4,-5}|{5,-5}|{6,-5}|{7,-5}|{8,-5}|{9,-67}|", "Tema", "Sunkumas", "Autorius", "Klausimas", "Ats. Nr.1", "Ats. Nr.2", "Ats. Nr.3", "Ats. Nr.4", "Teisingo Ats. Nr.", "Skiriami taškai už teisingą atsakymą");
            File.AppendAllText(filename, header + '\n');
            File.AppendAllText(filename, new string('-', 174) + '\n');

            string[] Lines = new string[register.Count()];

            for (int i = 0; i < register.Count(); i++)
            {
                Question question = register.Get(i);
                File.AppendAllText(filename, question.ToString());
            }

            File.AppendAllText(filename, new string('-', 174) + '\n');
        }
        /// <summary>
        /// prints out the best authors
        /// </summary>
        /// <param name="register"></param>
        /// <param name="HighestNumber"></param>
        /// <param name="WinnerAuthor"></param>
        public static void printBestAuthors(List<String> Authors)
        {
            Console.WriteLine("Unikalus autoriai ir ju kiekis");
            foreach (String Author in Authors)
            {
                Console.WriteLine(Author);
            }
            Console.WriteLine(Authors.Count);
            Console.WriteLine('\n');
        }
        /// <summary>
        /// aesthetic method, prints lines for good looking boxes
        /// </summary>
        public static void printLines()
        {
            Console.WriteLine(new string('-', 174));
        }
        /// <summary>
        /// prints out the hardest questions
        /// </summary>
        /// <param name="register"></param>
        public static void printHardestQuestions(QuestionRegister register)
        {
            Console.WriteLine("Sunkiausi Klausimai:");
            Console.WriteLine(new string('-', 174));
            for (int i = 0; i < register.Count(); i++)
            {
                Question question = register.Get(i);
                Console.WriteLine(question.ToString());
            }
            Console.WriteLine(new string('-', 174));
        }
        /// <summary>
        /// prints out the unique themes into CSV file
        /// </summary>
        /// <param name="ThemesCount"></param>
        /// <param name="filename"></param>
        public static void printThemes(List<string> Themes, string filename)
        {
            File.AppendAllText(filename, "Nevienodos temos, ir kiek ju yra:\n");
            
            foreach(string theme in Themes)
            {
                File.AppendAllText(filename, theme + "\n");
            }
            File.AppendAllText(filename, Themes.Count.ToString());
        }
        /// <summary>
        /// prints the sorted identical question register into CSV
        /// </summary>
        /// <param name="register"></param>
        /// <param name="filename"></param>
        public static void PrintSorted(QuestionRegister register, string filename)
        {
            File.AppendAllText(filename, "Surikiuotas vienodu klausimu sarasas\n");

            for (int i = 0; i < register.Count(); i++)
            {
                Question question = register.Get(i);
                string line = string.Format("{0};{1};{2}\n",question.question, question.author, question.theme);
                File.AppendAllText(filename, line);
            }

        }

    }
}
