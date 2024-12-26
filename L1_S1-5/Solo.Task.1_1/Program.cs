
using Solo.Task._1_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiški._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char character;
            int width;
            int amount = 0;
            

            Console.WriteLine("Įveskite bendrą spausdinamų simbolių kiekį");
            amount = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite vienos eilutės simbolių kiekį");
            width = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite spausdinamą simbolį");
            character = Console.ReadLine()[0];

            InOutUtils.printData(amount,width,character);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
