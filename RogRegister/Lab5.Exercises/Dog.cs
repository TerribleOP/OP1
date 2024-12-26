using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises
{
    class Dog : Animal
    {
        private const int VaccinationDuration = 1;
        public bool Aggresive { get; set; }
        public Dog(int id, string name, string breed, DateTime birthdate, Gender gender, bool aggresive) : base(id, name, breed, birthdate, gender)
        {
            this.Aggresive = aggresive;
        }
        public override bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration)
                .CompareTo(DateTime.Now) < 0;
            }
        }
    }
}
