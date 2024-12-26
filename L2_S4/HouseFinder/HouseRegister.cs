using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseFinder
{
    class HouseRegister
    {
        private List<House> AllHouses;
        public HouseRegister() 
        {
            AllHouses = new List<House>();
        }

        public HouseRegister(List<House> Houses)
        {
            AllHouses = new List<House>();
            foreach (House house in Houses)
            {
                this.AllHouses.Add(house);
            }
        }

        public void Add(House house)
        {
            AllHouses.Add(house);
        }

        public int HouseCount()
        {
            return AllHouses.Count;
        }

        public House HouseByIndex(int index)
        {
            return AllHouses[index];
        }

        public bool Contains(House house)
        {
            return this.AllHouses.Contains(house);
        }

        public HouseRegister FindCorrectHouses(int floor, int startingFloor, int endingFloor, int price)
        {
            HouseRegister CorrectHouses = new HouseRegister();
            foreach (House house in AllHouses)
            {
                if(house.roomCount>= floor && house.roomFloor>=startingFloor && house.roomFloor<=endingFloor && house.price <= price)
                {
                    CorrectHouses.Add(house);
                }
            }
            return CorrectHouses;

        }

    }
}
