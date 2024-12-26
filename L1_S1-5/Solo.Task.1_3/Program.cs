

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Task._1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber;
            double secondNumber;
            char actionOperator;
            double result = 0;
            char[] allowedOperators = { '+', '-', '*', '/' };

            Console.WriteLine("Įrašykite pirmą skaičių:");
            firstNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("Įrašykite operatorių:");
            actionOperator = Console.ReadLine()[0];
            Console.WriteLine("Įrašykite antra skaičių:");
            secondNumber = double.Parse(Console.ReadLine());

            if (!allowedOperators.Contains(actionOperator))
            {
                Console.WriteLine("Klaidinga operacija");
            }
            else if (actionOperator == '/' && secondNumber == 0)
            {
                Console.WriteLine("Dalyba iš 0 negalima");
            }
            else
            {
                switch (actionOperator)
                {
                    case '+':
                        result = firstNumber + secondNumber;
                        break;

                    case '-':
                        result = firstNumber - secondNumber;
                        break;

                    case '*':
                        result = firstNumber * secondNumber;
                        break;

                    case '/':
                        result = firstNumber / secondNumber;
                        break;
                }
                Console.WriteLine("atsakymas yra : {0}", result);
            }
            

        }
    }
}
