using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_4
{
    public class Basketball : Player
    {

        public int retakenBalls { get; set; }
        public int pointEarningPasses { get; set; }
        public Basketball(string teamName, string playerFirstName, string playerLastName, DateTime birthDate, int participationCount, int goalCount, int retakenBalls, int pointEarningPasses) : base(teamName, playerFirstName, playerLastName, birthDate, participationCount, goalCount)
        {
            this.retakenBalls = retakenBalls;
            this.pointEarningPasses = pointEarningPasses;
        }

        public override string ToString()
        {
            string line = string.Format(" {0} {1,-6} | {2,-21} |\n", base.ToString(), this.retakenBalls, this.pointEarningPasses);
            return line;
        }

    }
}
