using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OP_L5_U5
{
    class TestQuestion : Question
    {

        public string[] answerposibilies {  get; set; }

        public TestQuestion(string type, string theme, int difficulty, string author, string question, string answer, int points, string[] answerposibilies) : base(type, theme, difficulty, author, question, answer, points)
        {
            this.answerposibilies = answerposibilies;
        }
        /// <summary>
        /// base class + TestQuestion class ToString() override to print respective elements
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line = string.Format($"{base.ToString()} {answerposibilies[0],20} | {answerposibilies[1],20} | {answerposibilies[2],20} | {answerposibilies[3],20} |");
            return line;
        }
    }
}
