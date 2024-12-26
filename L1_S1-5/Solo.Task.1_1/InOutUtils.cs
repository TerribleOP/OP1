using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Task._1_1
{
    internal class InOutUtils
    {

        public static void printData(int amount, int width, char character)
        {

            for (int i = 0; i < amount / width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(character);
                }
                Console.WriteLine();


                //int leftOver = amount % width;

                //if (leftOver > 0)
                //{
                //    for (int i = 0; i < leftOver; i++)
                //    {
                //        Console.Write(character);
                //    }
                //    Console.WriteLine();
                //}

            }

        }
    }
}
