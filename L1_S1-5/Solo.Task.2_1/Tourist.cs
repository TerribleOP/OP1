using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Task._2_1
{
    class Tourist
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Money { get; set; }
        public double HelpsWithExpenses { get; set; }

        public Tourist(string name, string lastName, double money)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Money = money;
            this.HelpsWithExpenses = CalculateHelp(money);
        }

        private double CalculateHelp(double money)
        {
            return Money / 4.0;
        }

    }
}
