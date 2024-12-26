using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace L5_4
{
    public class Player
    {
        public string teamName { get; set; }
        public string playerFirstName { get; set; }
        public string playerLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int participationCount {  get; set; }
        public int goalCount { get; set; }

        public Player(string teamName, string playerFirstName, string playerLastName, DateTime birthDate, int participationCount, int goalCount)
        {
            this.teamName = teamName;
            this.playerFirstName = playerFirstName;
            this.playerLastName = playerLastName;
            this.BirthDate = birthDate;
            this.participationCount = participationCount;
            this.goalCount = goalCount;
        }

        public override string ToString()
        {
            string line = string.Format("| {0,15} | {1,15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,8} | {5,8} |",
                                this.teamName, this.playerFirstName, this.playerLastName, this.BirthDate, this.participationCount, this.goalCount);
            return line;
        }


    }

    

}
