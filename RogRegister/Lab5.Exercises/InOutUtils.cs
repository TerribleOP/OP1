using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5.Exercises
{

        static class InOutUtils
        {
        public static AnimalsContainer ReadAnimals(string fileName)
        {
            AnimalsContainer animals = new AnimalsContainer();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string type = values[0];
                int id = int.Parse(values[1]);
                string name = values[2];
                string breed = values[3];
                DateTime birthDate = DateTime.Parse(values[4]);
                Gender gender;
                Enum.TryParse(values[5], out gender); //tries to convert value to enum
                switch (type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        if (!animals.Contains(dog))
                        {
                            animals.Add(dog);
                        };
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        if (!animals.Contains(cat))
                        {
                            animals.Add(cat);
                        };
                        break;
                    case "GPIG":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        if (!animals.Contains(guineaPig))
                        {
                            animals.Add(guineaPig);
                        };
                        break;
                    default:
                        break;//unknown type
                }
            }
            return animals;
        }
        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }

        public static void PrintAnimals(string label, AnimalsContainer animals)
        {
            string dashes = new string('-', 125);
            Console.WriteLine(dashes);
            Console.WriteLine("| {0,15} |", label);
            Console.WriteLine(dashes);
            Console.WriteLine("| {0,15} | {1,8} | {2,15} | {3,15} | {4,12} | {5,8} | {6,12} | {7,12} |",
                "Rūšis", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Skiepijimo data", "Agresyvus");
            Console.WriteLine(dashes);
            if( animals.Count != 0)
            {
                for (int i = 0; i < animals.Count; i++)
                {
                    Animal animal = animals.Get(i);
                    string type = animal.GetType().Name;
                    switch (type)
                    {
                        case "Dog":
                            Dog dog = animal as Dog;
                            Console.WriteLine("| {0,15} | {1,-8} | {2,-15} | {3,-15} | {4,-12:yyyy-MM-dd} | {5,8} | {6,-15:yyyy-MM-dd} | {7,12} |",
                                type, animal.ID, animal.Name, animal.Breed, animal.Birthdate, animal.Gender, animal.LastVaccinationDate, dog.Aggresive);
                            break;
                        case "Cat":
                            Console.WriteLine("| {0,15} | {1,-8} | {2,-15} | {3,-15} | {4,-12:yyyy-MM-dd} | {5,8} | {6,-15:yyyy-MM-dd} | {7,12} |",
                                type, animal.ID, animal.Name, animal.Breed, animal.Birthdate, animal.Gender, animal.LastVaccinationDate, "-");
                            break;
                        case "GuineaPig":
                            Console.WriteLine("| {0,15} | {1,-8} | {2,-15} | {3,-15} | {4,-12:yyyy-MM-dd} | {5,8} | {6,-15} | {7,12} |",
                                type, animal.ID, animal.Name, animal.Breed, animal.Birthdate, animal.Gender, "-", "-");
                            break;
                        default:
                            Console.WriteLine("| {0,15} |", "Nežinoma rūšis");
                            break;//unknown type
                    }
                }
            }
            else
            {
                Console.WriteLine("|Nėra gyvūnų.|");
            }
            
        Console.WriteLine(dashes);
        }
        public static void PrintBreeds(List<string> Breeds)
        {
            foreach (string breed in Breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintAnimalsToCSVFile(string fileName, AnimalsContainer animals)
        {
            string[] lines = new string[animals.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5}",
            "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Skiepijimo data");
            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);
                if (animal != null) 
                {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5}",
                animal.ID, animal.Name, animal.Breed, animal.Birthdate, animal.Gender, animal.LastVaccinationDate);
                }
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
    
}
