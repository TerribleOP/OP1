using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace L5_4
{
    internal class PlayerRegister
    {
        private PlayerContainer Register;

        public PlayerRegister()
        {
            Register = new PlayerContainer();
        }
        public PlayerRegister(PlayerRegister Animals)
        {
            Register = new PlayerContainer();
        }
        public void Add(Player player)
        {
            Register.Add(player);
        }
        public int Count()
        {
            return this.Register.Count;
        }
        public Player Get(int index)
        {
            return this.Register.Get(index);
        }

        public bool Contains(Player player)
        {
            return this.Register.Contains(player);
        }
        public int AverageFromCityFootBall(List<Team> Teams, string City)
        {
            int result = 0;
            int count = 0;
            for (int i = 0; i < Register.Count; i++)
            {
                Player player = Register.Get(i);
                foreach(Team team in Teams)
                {
                    if(string.Equals(team.city, City, StringComparison.OrdinalIgnoreCase)
                        && player.teamName == team.teamName && player.GetType().Name == "Football")
                    {
                        result += player.goalCount;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return result / count;
            }
            else
            {
                return 0;
            }
        }
        public int AverageFromCityBasketBall(List<Team> Teams, string City)
        {
            int result = 0;
            int count = 0;
            for (int i = 0; i < Register.Count; i++)
            {
                Player player = Register.Get(i);
                foreach (Team team in Teams)
                {
                    if (string.Equals(team.city, City, StringComparison.OrdinalIgnoreCase)
                        && player.teamName == team.teamName && player.GetType().Name == "Basketball")
                    {
                        result += player.goalCount;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return result / count;
            }
            else
            {
                return 0;
            }
        }

        public PlayerRegister FullAttendenceAndGoalPercentage(List<Team> Teams, string City, int averageFootBall, int averageBasketBall)
        {
            PlayerRegister result = new PlayerRegister();
            for (int i = 0; i < Register.Count; i++)
            {
                Player player = Register.Get(i);
                foreach (Team team in Teams)
                {
                    if (player.GetType().Name == "Basketball" && averageBasketBall > 0)
                    {
                        if (string.Equals(team.city, City, StringComparison.OrdinalIgnoreCase)
                        && player.teamName == team.teamName
                        && player.participationCount >= team.playedGamesCount
                        && player.goalCount >= averageBasketBall)
                        {
                            result.Add(player);
                        }
                    }
                    if (player.GetType().Name == "Football" && averageFootBall > 0)
                    {
                        if (string.Equals(team.city, City, StringComparison.OrdinalIgnoreCase)
                        && player.teamName == team.teamName
                        && player.participationCount >= team.playedGamesCount
                        && player.goalCount >= averageFootBall)
                        {
                            result.Add(player);
                        }
                    }
                }
            }
            return result;
        }
    }
}
