using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_U2_5
{
    /// <summary>
    /// Class is meant to save the data set relating to the theme,difficulty,author,question, all possible answers in an array, the correct answer number, points.
    /// </summary>
    class Question
    {
        public string theme {  get; set; }
        public int difficulty { get; set; }
        public string author { get; set; }
        public string question { get; set; }
        public string[] answers { get; set; }
        public int answerNumber { get; set; }
        public int points { get; set; }

        public Question(string theme, int difficulty, string author, string question, string[] answers, int answerNumber, int points)
        {
            this.theme = theme;
            this.difficulty = difficulty;
            this.author = author;
            this.question = question;
            this.answers = answers;
            this.answerNumber = answerNumber;
            this.points = points;
        }

        /// <summary>
        /// Operator overload for the logical operation "==", it compares register data with a number.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool operator ==(Question question, int number)
        {
            return question.difficulty == number;
        }
        /// <summary>
        /// Operator overload for the logical operation "!=", it compares register data with a number.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool operator !=(Question question, int number)
        {
            return question.difficulty != number; ;
        }
        /// <summary>
        /// Operator overload for the method ".Equals()", it compares base to the object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// Operator overload for the method ".GetHashCode()", it returns the hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Operator overload for the method ".ToString()", it returns a formated list using the class variables.
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
                    answerNumber,
                    points);
            return line;
        }

    }
}
