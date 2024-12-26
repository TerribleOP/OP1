using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;

namespace L5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerRegister players = new PlayerRegister();
            
            //const string fileName = "data.csv";
            InOutUtils.readData(players, "data.csv");

            List<Team> teams = InOutUtils.ReadTeamData("datateam.csv");


            Console.WriteLine("Irasykite miesta");
            string City = Console.ReadLine();

            int averageFootball = players.AverageFromCityFootBall(teams, City);
            int averageBasketball = players.AverageFromCityBasketBall(teams, City);
            Console.WriteLine($"Krepsininku vidurkus: {averageBasketball}");
            Console.WriteLine($"Futbolininku vidurkus: {averageFootball}");

            PlayerRegister PlayersFromCityMeetingCriteria = players.FullAttendenceAndGoalPercentage(teams, City, averageFootball, averageBasketball);

            InOutUtils.printData(PlayersFromCityMeetingCriteria, City);

        }
    }
}
