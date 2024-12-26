using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HouseRegister register = InOutUtils.ReadHouses(@"HouseData.csv");

            InOutUtils.PrintHouses(register);

            (int floor, int startingFloor, int endingFloor, int price) = InOutUtils.StartingDataQuestions(@"HouseFinder.csv");

            HouseRegister fittingHouses = new HouseRegister();
            fittingHouses = register.FindCorrectHouses(floor, startingFloor, endingFloor, price);

            InOutUtils.PrintHouses(fittingHouses);
        }
    }
}
