using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_4
{
    public class Football : Player
    {
        public int yellowCardCount { get; set; }
        public Football(string teamName, string playerFirstName, string playerLastName, DateTime birthDate, int participationCount, int goalCount, int yellowCardCount)
            : base(teamName, playerFirstName, playerLastName, birthDate, participationCount, goalCount)
        {
           this.yellowCardCount = yellowCardCount;
        }

        public override string ToString()
        {
            return string.Format(" {0} {1,-30} |\n",
            base.ToString(), this.yellowCardCount);
        }
    }
}
