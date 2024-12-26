using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises
{
    class AnimalsComparator
    {
        public virtual int Compare(Animal a, Animal b, bool second)
        {
            if (second == false)
            {
                return a.CompareTo1(b);
            }
            else
            {
                return a.CompareTo2(b);
            }
        }
    }
}
