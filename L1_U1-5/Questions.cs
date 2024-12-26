// Edvinas Urbonas IFF4-6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_U1_5
{
    /// <summary>
    /// Class 'Question' is storing the data set related to the 10 questions in the inital data
    /// </summary>
     class Question
    {
        public string Theme { get; set; }
        public int Difficulty { get; set; }
        public string Author { get; set; }
        public string Task { get; set; }
        public string[] Answer { get; set; }
        public int CorrectAnswer {  get; set; }
        public int Points {  get; set; }


        public Question(string theme, int difficulty, string author, string task, string[] answer, int correctAnswer, int points)
        {
            this.Theme = theme;
            this.Difficulty = difficulty;
            this.Author = author;
            this.Task = task;
            this.Answer = answer;
            this.CorrectAnswer = correctAnswer;
            this.Points = points;
        }


    }
}
