using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Solo.Task._2_1
{
    static class InOutUtils
    {
        public static List<Tourist> ReadTourists(string filename)
        {
            List<Tourist> Tourists = new List<Tourist>();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in lines) 
            {
                string[] Values = line.Split(';');
                string name = Values[0];
                string lastName = Values[1];
                int money = int.Parse(Values[2]);
                Tourist tourist = new Tourist(name, lastName, money);
                Tourists.Add(tourist);
            }
            return Tourists;
        }

        public static void PrintTourists(List<Tourist> tourists, double total, List<Tourist> topContributors)
        {
            Console.WriteLine("Iš viso surinkta pinigų:{0}", total);
            Console.WriteLine("Daugiausia prisidėję:");
            foreach (var contributor in topContributors)
            {
                Console.WriteLine("|{0,10}|{1,10}|", contributor.Name, contributor.LastName);
            }
        }

    }

    


}
