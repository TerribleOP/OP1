using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace L2_U2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            File.Delete(@"Assosiation.txt");

            QuestionRegister infoSA = InOutUtils.readQuestions(@"Questions_infoSA.csv");
            QuestionRegister statSA = InOutUtils.readQuestions(@"Questions_StatSA.csv");

            InOutUtils.printInitialData(infoSA, "Assosiation.txt");
            InOutUtils.printInitialData(statSA, "Assosiation.txt");

            //List<string> UniqueAuthors = new List<string>();
            //UniqueAuthors.AddRange(infoSA.GetUniqueAuthors());
            //UniqueAuthors.AddRange(statSA.GetUniqueAuthors());

            Dictionary<string,int> WinnerAuthorOne = infoSA.FindTimesMentioned(infoSA.GetUniqueAuthors());
            Dictionary<string, int> WinnerAuthorTwo = statSA.FindTimesMentioned(statSA.GetUniqueAuthors());
  
            //int firstHighestNumber = infoSA.FindHighestMentionCount(WinnerAuthorOne);
            //int secondHighestNumber = statSA.FindHighestMentionCount(WinnerAuthorTwo);

            InOutUtils.printBestAuthors(infoSA, infoSA.FindHighestMentionCount(WinnerAuthorOne), WinnerAuthorOne);
            InOutUtils.printBestAuthors(statSA, statSA.FindHighestMentionCount(WinnerAuthorTwo), WinnerAuthorTwo);

            InOutUtils.printLines();
            InOutUtils.printHardestQuestions(infoSA);
            InOutUtils.printHardestQuestions(statSA);
            InOutUtils.printLines();

            //List<string> QuestionDataOne = infoSA.getAllQuestions();
            //List<string> QuestionDataTwo = statSA.getAllQuestions();
            //List<string> identicalQuestionData = statSA.FindIdenticalQuestions(infoSA.getAllQuestions(), statSA.getAllQuestions());

            InOutUtils.PrintIdenticalQuestions(statSA.FindIdenticalQuestions(infoSA.getAllQuestions(), statSA.getAllQuestions()));

        }
    }
}
