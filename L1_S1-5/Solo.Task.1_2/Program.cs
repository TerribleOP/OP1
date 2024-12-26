
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Task._1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double functionResult;
            double x;

            Console.WriteLine("Įrašykite x reikšmę");
            x = double.Parse(Console.ReadLine());

            if (x<0 && x>=-1)
            {
                functionResult = 1 / (x + 5);
            }
            else if (x < 1 && x >= 0)
            {
                functionResult = x + 1;
            }
            else
            {
                int calculation = (int)(Math.Pow(x, 2) + x + 1);
                functionResult = Math.Pow(calculation, 0.5);
            }
            Console.WriteLine("Jūsų atsakymas yra: {0}", functionResult);
        }
    }
}
