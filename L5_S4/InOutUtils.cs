using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L5_4
{
    class InOutUtils
    {

        public static void readData(PlayerRegister Register, string filename)
        {
            const int BasketballPlayerFields = 8;
            const int FootballPlayerFields = 7;
            string line;
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    int number = data.Count();
                    switch (number)
                    {
                        //Neptūnas;Mažeika;Martynas;1985-01-29;240;3400;700;1000
                        case BasketballPlayerFields:
                            string teamName = data[0];
                            string playerFirstName = data[1];
                            string playerLastName = data[2];
                            DateTime birthDate = DateTime.Parse(data[3]);
                            int participationCount = int.Parse(data[4]);
                            int goalCount = int.Parse(data[5]);
                            int retakenBalls = int.Parse(data[6]);
                            int pointEarningPasses = int.Parse(data[7]);
                            Basketball basketball = new Basketball(teamName, playerFirstName, playerLastName, birthDate, participationCount, goalCount, retakenBalls, pointEarningPasses);
                            if (!Register.Contains(basketball))
                            {
                                Register.Add(basketball);
                            }
                            break;
                        //Real Madrid;Benzema;Karim;1987-12-19;647;354;25
                        case FootballPlayerFields:
                            string teamName2 = data[0];
                            string playerFirstName2 = data[1];
                            string playerLastName2 = data[2];
                            DateTime birthDate2 = DateTime.Parse(data[3]);
                            int participationCount2 = int.Parse(data[4]);
                            int goalCount2 = int.Parse(data[5]);
                            int yellowCardCount = int.Parse(data[6]);
                            Football football = new Football(teamName2, playerFirstName2, playerLastName2, birthDate2, participationCount2, goalCount2, yellowCardCount);
                            if (!Register.Contains(football))
                            {
                                Register.Add(football);
                            }
                            break;
                    }
                }
            }
        }

        public static List<Team> ReadTeamData(string filename)
        {
            List<Team> Teams = new List<Team>();
            string line;
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    // Barcelona; Barcelona; Xavi Hernández; 3000
                    string[] data = line.Split(';');
                    string Name = data[0];
                    string City = data[1];
                    string Trainer = data[2];
                    int totalGames = int.Parse(data[3]);
                    Team team = new Team(Name, City, Trainer, totalGames);
                    if (!Teams.Contains(team))
                    {
                        Teams.Add(team);
                    }
                }
            }
            return Teams;
        }

        public static void printData(PlayerRegister Register, string city)
        {
            string dashes = new string('-', 125);
            

            if (Register.Count() != 0)
            {
                Console.WriteLine(dashes);
                Console.WriteLine("| {0,-121} |", $"Zaidejai isrinkti is {city}");
                Console.WriteLine(dashes);
                for (int i = 0; i < Register.Count(); i++)
                {
                    Player player = Register.Get(i);
                    string type = player.GetType().Name;
                    switch(type)
                    {
                        case "Basketball":
                            Basketball basketball = player as Basketball;
                            Console.WriteLine(basketball.ToString());
                        break;

                        case "Football":
                            Football football = player as Football;
                            Console.WriteLine(football.ToString());
                        break;

                        default:
                            Console.WriteLine("| {0,15} |", "Nezinoma rusis");
                        break;
                    }
                    Console.WriteLine(dashes);
                }
            }
            else
            {
                Console.WriteLine("Nera duomenu");
            }

        }
    }
}
