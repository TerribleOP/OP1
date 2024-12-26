

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Solo.Task._2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tourist> allTourists = InOutUtils.ReadTourists(@"Tourist.csv");

            double total = TaskUtils.FullSum(allTourists);

            List<Tourist> topContributors = TaskUtils.FindContributor(allTourists);

            InOutUtils.PrintTourists(allTourists, total, topContributors);


        }
    }
}
