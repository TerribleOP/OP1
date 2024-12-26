using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseFinder
{
    class House
    {

            public int number { get; set; }
            public double area { get; set; }
            public int roomCount { get; set; }  
            public double price { get; set; }
            public int phoneNumber { get; set; }
            public int roomFloor { get; set; }



        public House (int number, double area, int roomCount, double price, int phoneNumber)
        {
            this.number = number;
            this.area = area;
            this.roomCount = roomCount;
            this.price = price;
            this.phoneNumber = phoneNumber;
            this.roomFloor = CalculateRoomFloor(number);
            
        }

        private int CalculateRoomFloor(int number)
        {
            return ((number - 1) % 27) / 3 + 1; ;
        }
    }
}
