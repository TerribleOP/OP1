
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Task._1_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            String name;

            Console.WriteLine("Koks tavo vardas?");
            name = Console.ReadLine().ToLower();
            name = char.ToUpper(name[0]) + name.Substring(1);

            if (name.EndsWith("as"))
            {
                name = name.Substring(0, name.Length - 2) + "ai";
                Console.WriteLine("Labas,{0}!",name);
            }
            else if (name.EndsWith("is"))
            {
                name = name.Substring(0, name.Length - 2) + "i";
                Console.WriteLine("Labas, {0}!", name);
            }
            else if (name.EndsWith("ys"))
            {
                name = name.Substring(0, name.Length - 2) + "y";
                Console.WriteLine("Labas, {0}!", name);
            }
            else if (name.EndsWith("a"))
            {
                Console.WriteLine("Labas, {0}!", name);
            }
            else if (name.EndsWith("ė"))
            {
                name = name.Substring(0, name.Length - 1) + "e";
                Console.WriteLine("Labas, {0}!", name);
            }
            else
            {
                Console.WriteLine("Šitas vardas neatitinka uždavinio reikalavimų");
            }
        }
    }
}
