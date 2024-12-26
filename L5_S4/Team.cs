using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_4
{
    public class Team
    {
        public string teamName {  get; set; }
        public string city { get; set; }
        public string trainerFullName {  get; set; }
        public int playedGamesCount { get; set; }

        public Team(string teamName, string city, string trainerFullName, int playedGamesCount)
        {
            this.teamName = teamName;
            this.city = city;
            this.trainerFullName = trainerFullName;
            this.playedGamesCount = playedGamesCount;
        }



    }
}
