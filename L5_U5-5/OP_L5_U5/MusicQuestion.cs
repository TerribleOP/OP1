using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_L5_U5
{
    class MusicQuestion : Question
    {

        public string songFilename { get; set; }

        public MusicQuestion(string type, string theme, int difficulty, string author, string question, string answer, int points, string songFilename) : base(type, theme, difficulty, author, question, answer, points)
        {
            this.songFilename = songFilename;
        }
        /// <summary>
        /// base class + MusicQuestion class ToString() override to print respective elements
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line = string.Format($"{base.ToString()} {songFilename,20} | {'-',20} | {'-',20} | {'-',20} |");
            return line;
        }
    }
}
