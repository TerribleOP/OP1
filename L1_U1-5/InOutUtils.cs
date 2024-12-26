//Edvinas Urbonas IFF4-6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L1_U1_5
{
    static class InOutUtils
    {
        /// <summary>
        /// reads the initial data from a .csv file and stores it into a Question class list
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Question> ReadQuestions(string fileName)
        {
            List<Question> Questions = new List<Question>();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string theme = values[0].Trim();
                int difficulty =int.Parse(values[1].Trim());
                string author = values[2].Trim();
                string task = values[3].Trim();
                string[] questions = { values[4].Trim(), values[5].Trim(), values[6].Trim(), values[7].Trim() };
                int correctAnswer = int.Parse(values[8].Trim());
                int points = int.Parse(values[9].Trim());

                Question question = new Question(theme, difficulty, author, task, questions, correctAnswer,points);
                Questions.Add(question);
            }
            return Questions;
        }
        /// <summary>
        /// Prints the inital data into a .txt file
        /// </summary>
        /// <param name="Questions"></param>
        public static void PrintInitialData(List<Question> Questions)
        {
            string header;

            File.WriteAllText("PradDuomenys.txt", new string('-', 165));
            File.AppendAllText("PradDuomenys.txt", "\n");
            header = String.Format("|{0,-5}|{1,-5}|{2,-5}|{3,-5}|{4,-5}|{5,-5}|{6,-5}|{7,-5}|{8,-5}|{9,-71}|", "Tema", "Sunkumas", "Autorius", "Klausimas", "Ats. Nr.1", "Ats. Nr.2", "Ats. Nr.3", "Ats. Nr.4", "Teisingo Ats. Nr.", "Skiriami taškai už teisingą atsakymą |");
            File.AppendAllText("PradDuomenys.txt", header);
            File.AppendAllText("PradDuomenys.txt", new string('-', 165));
            File.AppendAllText("PradDuomenys.txt", "\n");
            string[] Lines = new string[Questions.Count];
            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i] = String.Format(
                    "|{0,-10}|" +
                    "{1,5}|" +
                    "{2,-15}|" +
                    "{3,-50}|" +
                    "{4,-19}|" +
                    "{5,-17}|" +
                    "{6,-17}|" +
                    "{7,-19}|" +
                    "{8,-1}|" +
                    "{9,-1}|",
                    Questions[i].Theme,
                    Questions[i].Difficulty,
                    Questions[i].Author,
                    Questions[i].Task,
                    Questions[i].Answer[0],
                    Questions[i].Answer[1],
                    Questions[i].Answer[2],
                    Questions[i].Answer[3],
                    Questions[i].CorrectAnswer,
                    Questions[i].Points);
            }
            File.AppendAllLines("PradDuomenys.txt", Lines);
        }

        /// <summary>
        /// Method prints out the hardest subject and the winner author into console, and the randomized 5 questions into a .csv file
        /// </summary>
        /// <param name="Questions"></param>
        /// <param name="difficultyMax"></param>
        /// <param name="Author"></param>
        /// <param name="winnerIndex"></param>
        /// <param name="winnerPoints"></param>
        /// <param name="refinedQuestions"></param>
        public static void PrintQuestions(List<Question> Questions, int difficultyMax, List<string> Author, int winnerIndex, int winnerPoints, List<Question> refinedQuestions)
        {
            switch (difficultyMax)
            {
                case -1:
                    Console.WriteLine("Error su duomenimis");
                    break;
                case 1:
                    Console.WriteLine("Matematika sunkiausia");
                    break;
                case 2:
                    Console.WriteLine("Dailė sunkiausia");
                    break;
                case 3:
                    Console.WriteLine("Literatūra sunkiausia");
                    break;
                case 4:
                    Console.WriteLine("Matematika ir dailė sunkiausia");
                    break;
                case 5:
                    Console.WriteLine("Dailė ir literatūra sunkiausia");
                    break;
                case 6:
                    Console.WriteLine("Literatūra ir Mmtematika sunkiausia");
                    break;
                case 7:
                    Console.WriteLine("Visos temos yra vienodo sunkumo");
                    break;
            }

            Console.WriteLine("Daugiasia parašęs autorius: {0}. Jis/Ji buvo paminetas/ta {1} kartus ", Author[winnerIndex], winnerPoints);

            string[] lines = new string[refinedQuestions.Count];
            for (int i = 0; i < lines.Length; i++)
            {               
                string[] answers = refinedQuestions[i].Answer;    
                lines[i] = String.Format(
                    "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",
                    refinedQuestions[i].Theme,
                    refinedQuestions[i].Difficulty,
                    refinedQuestions[i].Author,
                    refinedQuestions[i].Task,
                    refinedQuestions[i].Answer[0],
                    refinedQuestions[i].Answer[1],
                    refinedQuestions[i].Answer[2],
                    refinedQuestions[i].Answer[3],
                    refinedQuestions[i].CorrectAnswer,
                    refinedQuestions[i].Points
                );
            }
            File.WriteAllLines("Klausimas1.csv", lines, Encoding.UTF8);
        }
    }
}
