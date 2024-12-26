using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace HouseFinder
{
    internal class InOutUtils
    {
        public static HouseRegister ReadHouses(string filename)
        {
            HouseRegister Houses = new HouseRegister();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                int number = int.Parse(values[0]);
                double area = double.Parse(values[1]);
                int roomCount = int.Parse(values[2]);
                double price = double.Parse(values[3]);
                int phoneNumber = int.Parse(values[4]);

                House house = new House(number, area, roomCount, price, phoneNumber);
                if(!Houses.Contains(house))
                {
                    Houses.Add(house);
                }

            }
            return Houses;
        }

        public static void PrintHouses(HouseRegister register)
        {
            Console.WriteLine(new string('-', 72));
            Console.WriteLine("|{0,-8}|{1,-5}|{2,-15}|{3,-12}|{4,-15}|{5,-10}|", "Buto nr", "Dydis", "Kambariu Kiekis", "Kaina", "Telefono nr.", "Aukstas");
            Console.WriteLine(new string('-', 72));
            for (int i = 0; i < register.HouseCount(); i++)
            {
                House house = register.HouseByIndex(i);
                Console.WriteLine("|{0,8}|{1,5}|{2,15}|{3,12}|{4,15}|{5,10}|", house.number, house.area, house.roomCount, house.price, house.phoneNumber, house.roomFloor);

            }
            Console.WriteLine(new string('-', 72));
        }

        public static (int floor, int startingFloor, int endingFloor, int price) StartingDataQuestions(string filename)
        {
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);

            int functionFloor = 0;
            int functionStartingFloor = 0;
            int functionEndingFloor = 0;
            int functionPrice =0;

            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                functionFloor = int.Parse(values[0]);
                string temporarySplit = values[1];
                string[] numberValues = temporarySplit.Split(',');
                functionStartingFloor = int.Parse(numberValues[0]);
                functionEndingFloor = int.Parse(numberValues[1]);
                functionPrice = int.Parse(values[2]); 
            }
            return (functionFloor, functionStartingFloor, functionEndingFloor, functionPrice);
        }


    }
}
