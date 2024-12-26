using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace OP_L5_U5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string InitialDataPath = "InitialData.txt";
            const string sortedDataPath = "Klausimai.csv";
            const string historyDataPath = "Istoriniai.csv";
            File.Delete(InitialDataPath);
            File.Delete(sortedDataPath);
            File.Delete(historyDataPath);

            const string infoSADataPath = "InfoSAdata.csv";
            const string StatiusSADataPath = "Statiusdata.csv";
            const string VivatSADataPath = "Vivatdata.csv";
            QuestionRegister InfoSA = InOut.readData(infoSADataPath);
            QuestionRegister StatSA = InOut.readData(StatiusSADataPath);
            QuestionRegister VivatSA = InOut.readData(VivatSADataPath);

            File.AppendAllText(InitialDataPath, "Pradiniai Duomenys:\n");
            InOut.printLines(InitialDataPath);
            InOut.PrintHeader(InitialDataPath);
            InOut.printLines(InitialDataPath);
            InOut.PrintInitialData(InfoSA,InitialDataPath);
            InOut.printLines(InitialDataPath);
            InOut.PrintInitialData(StatSA, InitialDataPath);
            InOut.printLines(InitialDataPath);
            InOut.PrintInitialData(VivatSA, InitialDataPath);
            InOut.printLines(InitialDataPath);
            Process.Start("notepad.exe", InitialDataPath);

            // Raskite, kas sukūrė daugiausiai klausimų, autoriaus vardą bei klausimų kiekį atspausdinkite ekrane.
            List<string> UniqueAuthors = new List<string>();
            InfoSA.CheckForUniqueAuthors(UniqueAuthors);
            StatSA.CheckForUniqueAuthors(UniqueAuthors);
            VivatSA.CheckForUniqueAuthors(UniqueAuthors);

            int count = 0;
            string highestAuthor = string.Empty;
            InfoSA.HighestCount(UniqueAuthors, ref count, ref highestAuthor);
            StatSA.HighestCount(UniqueAuthors, ref count, ref highestAuthor);
            VivatSA.HighestCount(UniqueAuthors, ref count, ref highestAuthor);
            InOut.PrintOverAllHighest(highestAuthor, count);


            //Raskite, kas sukūrė daugiausiai klausimų kiekvienoje atstovybėje (bendrai paėmus), autoriaus vardą bei klausimų kiekį atspausdinkite ekrane.
            //Kas sukūrė daugiausia muzikinių klausimų kiekvienoje atstovybėje, autoriaus vardą bei klausimų kiekį atspausdinkite ekrane.

            UniqueAuthors.Clear();
            int InfosaNormalCount = 0;
            InfoSA.CheckForUniqueAuthors(UniqueAuthors);
            InfoSA.HighestCount(UniqueAuthors, ref InfosaNormalCount, ref highestAuthor);
            InOut.PrintEachStudentAssosiation(highestAuthor, InfosaNormalCount, InfoSA);

            UniqueAuthors.Clear();
            int infosaMusicalCount = 0;
            InfoSA.CheckForUniqueMusicQuestionAuthors(UniqueAuthors);
            InfoSA.HighestMusicalCount(UniqueAuthors, ref infosaMusicalCount, ref highestAuthor);
            InOut.PrintEachStudentAssosiationMusical(highestAuthor, infosaMusicalCount, InfoSA);


            UniqueAuthors.Clear();
            int statsaNormalCount = 0;
            StatSA.CheckForUniqueAuthors(UniqueAuthors);
            StatSA.HighestCount(UniqueAuthors, ref statsaNormalCount, ref highestAuthor);
            InOut.PrintEachStudentAssosiation(highestAuthor, statsaNormalCount, StatSA);

            UniqueAuthors.Clear();
            int statsaMusicalCount = 0;
            StatSA.CheckForUniqueMusicQuestionAuthors(UniqueAuthors);
            StatSA.HighestMusicalCount(UniqueAuthors, ref statsaMusicalCount, ref highestAuthor);
            InOut.PrintEachStudentAssosiationMusical(highestAuthor, statsaMusicalCount, StatSA);

            UniqueAuthors.Clear();
            int vivatsaNormalCount = 0;
            VivatSA.CheckForUniqueAuthors(UniqueAuthors);
            VivatSA.HighestCount(UniqueAuthors, ref vivatsaNormalCount, ref highestAuthor);
            InOut.PrintEachStudentAssosiation(highestAuthor, vivatsaNormalCount, VivatSA);

            UniqueAuthors.Clear();
            int vivatsaMusicalCount = 0;
            VivatSA.CheckForUniqueMusicQuestionAuthors(UniqueAuthors);
            VivatSA.HighestMusicalCount(UniqueAuthors, ref vivatsaMusicalCount, ref highestAuthor);
            InOut.PrintEachStudentAssosiationMusical(highestAuthor, vivatsaMusicalCount, VivatSA);

            //Sudarykite visų klausimų sąrašą, įrašykite į failą „Klausimai.csv“, klausimus išrikiuokite pagal temą ir sudėtingumą.

            QuestionRegister unitedDatabase = new QuestionRegister();
            InfoSA.AddToUnitedDataBase(unitedDatabase);
            StatSA.AddToUnitedDataBase(unitedDatabase);
            VivatSA.AddToUnitedDataBase(unitedDatabase);
            unitedDatabase.Sort(new QuestionComparitor());
            InOut.PrintResultToCSV(unitedDatabase, sortedDataPath);
            Process.Start("notepad.exe", sortedDataPath);

            //Sudarykite visų klausimų, kurių tema „istorinis“, sąrašą, ir įrašykite juos į failą „Istoriniai.csv“.

            QuestionRegister HistoryQuestions = unitedDatabase.FindHistoryThemeQuestions();
            InOut.PrintResultToCSV(HistoryQuestions, historyDataPath);
            Process.Start("notepad.exe", historyDataPath);
        }
    }
}
