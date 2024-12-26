using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L3_U3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete(@"VienodiKlausimai.csv");
            File.Delete(@"TemuSkaicius.csv");
            File.Delete(@"Assosiation.txt");

            QuestionRegister infoSA = InOutUtils.ReadQuestions(@"Questions_infoSA.csv");
            QuestionRegister statSA = InOutUtils.ReadQuestions(@"Questions_statSA.csv");

            InOutUtils.printInitialData(infoSA, "Assosiation.txt");
            InOutUtils.printInitialData(statSA, "Assosiation.txt");

            QuestionRegister UnitedDataBase = new QuestionRegister();
            infoSA.AddToUnitedDataBase(UnitedDataBase);
            statSA.AddToUnitedDataBase(UnitedDataBase);
            InOutUtils.printBestAuthors(UnitedDataBase.GetUniqueAuthors());

            QuestionRegister HardestQuestions = new QuestionRegister();
            infoSA.FindHardestQuestions(HardestQuestions);
            statSA.FindHardestQuestions(HardestQuestions);
            InOutUtils.printHardestQuestions(HardestQuestions);


            List<string> Themes = new List<string>();
            infoSA.FindThemeNames(Themes);
            statSA.FindThemeNames(Themes);
            InOutUtils.printThemes(Themes, "TemuSkaicius.csv");

            QuestionRegister IdenticalQuestions = (statSA.FindIdenticalQuestions(infoSA, statSA));
            IdenticalQuestions.Sort();
            InOutUtils.PrintSorted(IdenticalQuestions, "VienodiKlausimai.csv");

        }
    }
}
