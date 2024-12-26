using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_L5_U5
{
    class QuestionComparitor
    {
        /// <summary>
        /// a seperate compartor function inside a QuestionComparitor class
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public virtual int Compare(Question a, Question b)
        {
           return a.CompareTo(b);
        }
    }
}
