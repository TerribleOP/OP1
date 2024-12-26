using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises
{
    abstract class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastVaccinationDate { get; set; }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.Birthdate.Year;
                if (this.Birthdate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        public abstract bool RequiresVaccination { get; }
        public Animal(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.Birthdate = birthDate;
            this.Gender = gender;
        }
        public override bool Equals(object other)
        {
            return this.ID == ((Animal)other).ID;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
        public int CompareTo1(Animal other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                return this.ID.CompareTo(other.ID);
            }
            return result;
        }
        public int CompareTo2(Animal other)
        {
            int result = this.Birthdate.CompareTo(other.Birthdate);
            if (result == 0)
            {
                return this.ID.CompareTo(other.ID);
            }
            return result;
        }

    }
}
