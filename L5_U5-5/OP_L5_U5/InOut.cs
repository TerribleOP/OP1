using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OP_L5_U5
{
    class InOut
    {
        /// <summary>
        /// reads initial data
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static QuestionRegister readData(string filename)
        {
            QuestionRegister fileData = new QuestionRegister();
            string[] lines = File.ReadAllLines(filename);
            fileData.studentAssosiationName = lines[0];

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] data = line.Split(';');
                string type = data[0];
                string theme = data[1];
                int difficulty = int.Parse(data[2]);
                string author = data[3];
                string createdQuestion = data[4];
                string answer = data[5];
                int points = int.Parse(data[6]);
                switch (type)
                {
                    case "open":
                        Question question = new Question(type,theme,difficulty,author, createdQuestion, answer,points);
                        if (!fileData.Contains(question))
                        {
                            fileData.Add(question);
                        }
                        break;
                        
                    case "closed":
                        string[] answers = { data[7], data[8], data[9], data[10] };
                        TestQuestion testquestion = new TestQuestion(type, theme, difficulty, author, createdQuestion, answer, points, answers);
                        if (!fileData.Contains(testquestion))
                        {
                            fileData.Add(testquestion);
                        }
                        break;

                    case "musical":
                        string filepath = data[7];
                        MusicQuestion musicQuestion = new MusicQuestion(type, theme, difficulty, author, createdQuestion, answer, points, filepath);
                        if (!fileData.Contains(musicQuestion))
                        {
                            fileData.Add(musicQuestion);
                        }
                        break;

                    default:
                        Console.WriteLine("UNKNOWN QUESTION TYPE");
                        break;

                }
            }
            return fileData;
        }
        /// <summary>
        /// prints a line, used for styling 
        /// </summary>
        /// <param name="filepath"></param>
        public static void printLines(string filepath)
        {
            File.AppendAllText(filepath, new string('-', 236) + "\n");
        }
        /// <summary>
        /// prints initial data into a .TXT file
        /// </summary>
        /// <param name="Register"></param>
        /// <param name="filename"></param>
        public static void PrintInitialData(QuestionRegister Register, string filename)
        {
            File.AppendAllText(filename, Register.studentAssosiationName + "\n");
            for (int i = 0; i < Register.Count(); i++)
            {
                Question question = Register.Get(i);
                string type = question.type;

                switch (type)
                {
                    case "open":
                        
                        File.AppendAllText(filename, question.ToString() +'-'+$" {' ',89}" + "|\n");
                        break;

                    case "closed":
                        TestQuestion testQuestion = question as TestQuestion;
                        File.AppendAllText(filename, testQuestion.ToString() + "\n");
                        break;

                    case "musical":
                        MusicQuestion musicalQuestion = question as MusicQuestion;
                        File.AppendAllText(filename, musicalQuestion.ToString() + "\n");
                        break;
                }
            }
        }

        public static void PrintHeader(string filename)
        {
            string header = string.Format($"{"Type",10} | {"Theme",5} | {"Difficulty",5} | {"Author",14} | {"Question",60} | {"Answers",25} | {"Points",4} | {"Different types of answer/ no asnwer",4} |");
            File.AppendAllText(filename, header + '\n');
        }

        /// <summary>
        /// prints the best question author from the entire data set
        /// </summary>
        /// <param name="author"></param>
        /// <param name="count"></param>
        public static void PrintOverAllHighest(string author, int count)
        {
            if (count>0)
            {
                Console.WriteLine($"Daugiausia klausimu sukure: {author}, klausimu kiekis: {count}\n");
            }
            else
            {
                Console.WriteLine("Nėra daugiausiai sukuriusio klausimu\n");
            }
        }
        /// <summary>
        /// prints the best question author and their student SA
        /// </summary>
        /// <param name="author"></param>
        /// <param name="count"></param>
        /// <param name="Register"></param>
        public static void PrintEachStudentAssosiation(string author, int count, QuestionRegister Register)
        {
            
            if (count > 0)
            {
                Console.WriteLine($"Daugiausia muzikos klausimu is {Register.studentAssosiationName} sukure: {author}, klausimu kiekis: {count}");
            }
            else
            {
                Console.WriteLine($"Nėra klausimu is {Register.studentAssosiationName}");
            }
        }
        /// <summary>
        /// prints the best musical question author and their student SA
        /// </summary>
        /// <param name="author"></param>
        /// <param name="count"></param>
        /// <param name="Register"></param>
        public static void PrintEachStudentAssosiationMusical(string author, int count, QuestionRegister Register)
        {
            
            if (count > 0)
            {
                Console.WriteLine($"Daugiausia muzikos klausimu is {Register.studentAssosiationName} sukure: {author}, klausimu kiekis: {count}\n");
            }
            else
            {
                Console.WriteLine($"Nėra muzikos klausimu is {Register.studentAssosiationName}\n");
            }
        }

        /// <summary>
        /// Prints the register into a .CSV file
        /// </summary>
        /// <param name="Register"></param>
        /// <param name="filename"></param>
        public static void PrintResultToCSV(QuestionRegister Register, string filename)
        {
            for (int i = 0; i < Register.Count(); i++)
            {
                Question question = Register.Get(i);
                string type = question.type;

                switch (type)
                {
                    case "open":
                        File.AppendAllText(filename, question.ToString() + "\n");
                        break;

                    case "closed":
                        TestQuestion testQuestion = question as TestQuestion;
                        File.AppendAllText(filename, testQuestion.ToString() + "\n");
                        break;

                    case "musical":
                        MusicQuestion musicalQuestion = question as MusicQuestion;
                        File.AppendAllText(filename, musicalQuestion.ToString() + "\n");
                        break;
                }
            }
            if(!(Register.Count()>0))
            {
                
                File.AppendAllText(filename, "Duomenu nera");
            }    
        }

    }
}
