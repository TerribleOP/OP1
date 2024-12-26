using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Task._2_1
{
    static class TaskUtils
    {

        public static double FullSum(List<Tourist> tourists)
        {
            double fullSum = 0;
            foreach (Tourist tourist in tourists)
            {
                fullSum += tourist.HelpsWithExpenses;

            }
            return fullSum;
        }
        
        public static List<Tourist> FindContributor(List<Tourist> tourists)
        {
            List<Tourist> contributors = new List<Tourist>();
            double maximumMoney = tourists[0].HelpsWithExpenses;
            for (int i = 1; i < tourists.Count; i++)
            {
                if (tourists[i].HelpsWithExpenses>=maximumMoney)
                {
                    contributors.Add(tourists[i]);
                    maximumMoney = tourists[i].HelpsWithExpenses;
                }
            }
            return contributors;
        }

    }
}
