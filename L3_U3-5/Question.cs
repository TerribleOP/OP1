using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_U3_5
{
    class Question
    {
        public string theme {  get; set; }
        public int difficulty { get; set; }
        public string author { get; set; }
        public string question { get; set; }
        public string[] answers { get; set; }
        public int correctAnswer { get; set; }
        public int points { get; set; }

        public Question(string theme, int difficulty, string author, string question, string[] answers, int correctAnswer, int points)
        {
            this.theme = theme;
            this.difficulty = difficulty;
            this.author = author;
            this.question = question;
            this.answers = answers;
            this.correctAnswer = correctAnswer;
            this.points = points;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line;
            line = string.Format(
                    "|{0,-10}|" +
                    "{1,8}|" +
                    "{2,-16}|" +
                    "{3,-55}|" +
                    "{4,-19}|" +
                    "{5,-17}|" +
                    "{6,-17}|" +
                    "{7,-19}|" +
                    "{8,-1}|" +
                    "{9,-1}|\n",
                    theme,
                    difficulty,
                    author,
                    question,
                    answers[0],
                    answers[1],
                    answers[2],
                    answers[3],
                    correctAnswer,
                    points);
            return line;
        }
        /// <summary>
        /// method override to compare register question element
        /// </summary>
        /// <param name="question"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool operator ==(Question question, Question question2)
        {
            return question.question == question2.question;
        }
        /// <summary>
        /// method override to compare register question element
        /// </summary>
        /// <param name="question"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool operator !=(Question question, Question question2)
        {
            return question.question != question2.question;
        }
        /// <summary>
        /// method override to compare an object with base
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// method override to compare hashcodes
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// allows the Sort method, to sort the register by themes and then by authors alphabetically.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Question other)
        {
            int comparison = this.theme.CompareTo(other.theme);
            if (comparison != 0)
            {
                return comparison;
            }
            else
            {
                return this.author.CompareTo(other.author);
            }
        }

    }

}
