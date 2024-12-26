using Lab5.Exercises;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab5.Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            const string label1 = "Prad. duomenys";

            AnimalsContainer allDogs = InOutUtils.ReadAnimals(@"Animals.csv");
            AnimalsContainer allDogsCopy = new AnimalsContainer(allDogs);
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            allDogs.UpdateVaccinationsInfo(VaccinationsData);
            InOutUtils.PrintAnimals(label1, allDogs);
            
            Console.WriteLine("Kokius gyvunus atrinkti?");
            string selectedBreed = Console.ReadLine();
            AnimalsContainer FilteredByBreed = allDogs.FilterByBreed(selectedBreed);
 
            AnimalsContainer NeedVaccines = allDogs.FilterByVaccinationExpired();
            InOutUtils.PrintAnimals("Reikia skiepyti (" + selectedBreed + ")", NeedVaccines.Intersect(FilteredByBreed));

            const string label4 = "Kopija";
            InOutUtils.PrintAnimals(label4, allDogsCopy);
            const string label5 = "Sort (vardas, ID)";
            bool second = false;
            allDogs.Sort(second);
            InOutUtils.PrintAnimals(label5, allDogs);
            const string label6 = "Sort (Gim. data, ID)";
            second = true;
            allDogs.Sort(second);
            InOutUtils.PrintAnimals(label6, allDogs);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintAnimalsToCSVFile(fileName, FilteredByBreed);
            
            
            
        }

    }
}
