using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5.Exercises
{
    class AnimalsContainer
    {
        private Animal[] animals;
        public int Count { get; private set; }
        private int Capacity;
        public AnimalsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.animals = new Animal[capacity];
        }
        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = animal;
        }
        public Animal Get(int index)
        {
            return this.animals[index];
        }
        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; ++i)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }
        }

        public void Put(Animal animal, int index)
        {
            if(index >= 0 && index < this.Count)
            {
                this.animals[index] = animal;
            }
        }

        public void Insert(Animal animal, int index)
        {
            if(this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count-1; i >= index; i--)
            {
                animals[i + 1] = this.animals[i];
            }
            this.animals[index] = animal;
            this.Count++;
        }
        public void Remove(Animal animal)
        {
            int index = -1;
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (this.animals[i].ID == animal.ID)
                {
                    index = i;
                }
            }
            if(index > -1)
            {
                RemoveAt(index);
            }

        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count -1; i++)
            {
                this.animals[i] = this.animals[i+1];
            }
            animals[this.Count - 1] = null;
            this.Count--;
        }
        public void Sort(bool second)
        {
            Sort(new AnimalsComparator(), second);
        }
        public void Sort(AnimalsComparator comparator, bool second)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                        if (comparator.Compare(a, b, second) > 0)
                        {
                            this.animals[i] = b;
                            this.animals[i + 1] = a;
                            flag = true;
                        }
                }
            }
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);
                if (animal.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        
        public Animal FindOldestAnimal()
        {
            Animal animal = FindOldestAnimal(this.animals);
            return animal;
        }

        private Animal FindOldestAnimal(Animal[] animals)
        {
            Animal oldest = animals[0];
            for (int i = 1; i < this.Count; i++)
            {
                Animal animal = animals[i];
                if (DateTime.Compare(oldest.Birthdate, animal.Birthdate) > 0)
                {
                    oldest = animal;
                }
            }
            return oldest;
        }
        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);
                string breed = animal.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        
        public AnimalsContainer FilterByBreed(string breed)
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.animals[i];
                if (animal.Breed.Equals(breed)) // uses string method Equals()
                {

                    Filtered.Add(animal);
                }
            }
            return Filtered;
        }
        public Animal FindOldestBreedDog(string breed)
        {
            Animal oldestbreed = animals[0]; // means least value

            for (int i = 1; i < this.Count; i++)
            {
                if (animals[i].Breed == breed)
                {
                    if (DateTime.Compare(animals[i].Birthdate, oldestbreed.Birthdate) < 0)
                    {
                        oldestbreed = animals[i];
                    }
                }
            }
            return oldestbreed;
        }
        public Animal FindFrequentDog()
        {
            Animal frequent = animals[0]; // means least value
            for (int i = 1; i < this.Count; i++)
            {
                if (animals[i].Breed == animals[i - 1].Breed)
                {
                    frequent = animals[i];
                }
            }
            return frequent;

        }
        private Animal FindDogByID(int ID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);
                if (animal.ID == ID)
                {
                    return animal;
                }
            }
            return null;
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                if (this.FindDogByID(vaccination.AnimalID) != null)
                {
                    Animal animal = this.FindDogByID(vaccination.AnimalID);
                    if (vaccination > animal.LastVaccinationDate)
                    {
                        animal.LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }
        public AnimalsContainer FilterByVaccinationExpired()
        {
            AnimalsContainer NotVaccinated = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = animals[i];
                if (animal.RequiresVaccination == true)
                {
                    NotVaccinated.Add(animal);
                }
            }
            return NotVaccinated;
        }
        public AnimalsContainer(AnimalsContainer container) : this() //calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public AnimalsContainer Intersect(AnimalsContainer other)
        {
            AnimalsContainer result = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.animals[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
