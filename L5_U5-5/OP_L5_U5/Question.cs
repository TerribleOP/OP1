using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_L5_U5
{
    class Question
    {
        public string type { get; set; }
        public string theme { get; set; }
        public int difficulty { get; set; }
        public string author { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public int points { get; set; }

        public Question(string type, string theme, int difficulty, string author, string question, string answer, int points)
        {
            this.type = type;
            this.theme = theme;
            this.difficulty = difficulty;
            this.author = author;
            this.question = question;
            this.answer = answer;
            this.points = points;
        }
        /// <summary>
        /// base class ToString() override to print respective elements in a formated string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line = string.Format($"{this.type,10} | {this.theme,10} | {this.difficulty,2} | {this.author,17} | {this.question,60} | {this.answer,25} | {this.points,5} |");
            return line;
        }

        /// <summary>
        /// compare to class - compares themes, if they are equal compares difficulty
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Question other)
        {
            int result = this.theme.CompareTo(other.theme);
            if (result == 0)
            {
                return this.difficulty.CompareTo(other.difficulty);
            }
            return result;
        }
    }
}
