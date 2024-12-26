using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises
{

    class AnimalsRegister
    {
        private AnimalsContainer AllAnimals;

        public AnimalsRegister()
        {
            AllAnimals = new AnimalsContainer();
        }
        public AnimalsRegister(AnimalsContainer Animals)
        {
            AllAnimals = new AnimalsContainer();
        }
        public void Add(Animal animal)
        {
            AllAnimals.Add(animal);
        }
        public int AnimalsCount()
        {
            return this.AllAnimals.Count;
        }
        public Animal Animalsindex(int index)
        {
            return this.AllAnimals.Get(index);
        }
        
    }
}
