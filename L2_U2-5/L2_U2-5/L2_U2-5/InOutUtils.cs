using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;

namespace L2_U2_5
{

    class InOutUtils
    {
        /// <summary>
        /// reads and return the initial data set into the register.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="association"></param>
        /// <returns></returns>
        public static QuestionRegister readQuestions(string filename)
        {
            QuestionRegister Questions = new QuestionRegister();
            string[] lines = File.ReadAllLines(filename);
            Questions.facultyName = lines[0];

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

                Question question = new Question (theme, difficulty, author, task, answers, correctAnswer, points);
                if(!Questions.Contains(question))
                {
                    Questions.Add(question);
                }
            }
            return Questions;
        }
        /// <summary>
        /// print the initial data into a .txt file
        /// </summary>
        /// <param name="register"></param>
        /// <param name="association"></param>
        /// <param name="filename"></param>
        public static void printInitialData(QuestionRegister register, string filename)
        {
            
            File.AppendAllText(filename, new string('-', 174) + '\n');
            string department = string.Format("{0,-173}|\n", register.facultyName);
            File.AppendAllText(filename, department);
            File.AppendAllText(filename, new string('-', 174) + '\n');

            string header = String.Format("|{0,-10}|{1,-8}|{2,-16}|{3,-5}|{4,-5}|{5,-5}|{6,-5}|{7,-5}|{8,-5}|{9,-67}|", "Tema", "Sunkumas", "Autorius", "Klausimas", "Ats. Nr.1", "Ats. Nr.2", "Ats. Nr.3", "Ats. Nr.4", "Teisingo Ats. Nr.", "Skiriami taškai už teisingą atsakymą");
            File.AppendAllText(filename, header + '\n');
            File.AppendAllText(filename, new string('-', 174) + '\n');

            string[] Lines = new string[register.QuestionCount()];

            for(int i = 0; i < register.QuestionCount(); i++)
            {
                Question question = register.QuestionByIndex(i);
                    File.AppendAllText(filename, question.ToString());
            }
            
            File.AppendAllText(filename, new string('-', 174) + '\n');
        }
        /// <summary>
        /// prints the authors who have been mentioned the most, aswell as how many times they were mentioned
        /// </summary>
        /// <param name="association"></param>
        /// <param name="HighestNumber"></param>
        /// <param name="WinnerAuthor"></param>
        public static void printBestAuthors(QuestionRegister register, int HighestNumber, Dictionary<string,int> WinnerAuthor)
        {
            Console.WriteLine(register.facultyName);
            foreach (KeyValuePair<string,int> KVP in WinnerAuthor)
            {
                string author = KVP.Key;
                int mentions = KVP.Value;
                if(mentions==HighestNumber)
                {  
                    Console.WriteLine("{0} {1} ", author, mentions);    
                }
            }
            Console.WriteLine('\n');
        }
        /// <summary>
        /// print all the data relating to every hard question from both data sets.
        /// </summary>
        /// <param name="register"></param>
        public static void printHardestQuestions(QuestionRegister register)
        {
            
            for (int i=0; i < register.QuestionCount(); i++)
            {
                Question question = register.QuestionByIndex(i);
                if (question == 3)
                {
                    Console.WriteLine(question.ToString());
                }
                
            }  
        }
        /// <summary>
        /// a simple style method meant to give frames for the printHardestQuestion() method
        /// </summary>
        public static void printLines()
        {
            Console.WriteLine(new string('-', 174));
        }

        /// <summary>
        /// prints every identical question into a .csv file
        /// </summary>
        /// <param name="Questions"></param>
        public static void PrintIdenticalQuestions(List<string> Questions)
        {
            File.WriteAllText("VienodiKlausimai.csv", "", Encoding.UTF8);
            foreach (string question in Questions)
            {
                File.AppendAllText("VienodiKlausimai.csv", question + ';', Encoding.UTF8);
            }
        }
    }
}
