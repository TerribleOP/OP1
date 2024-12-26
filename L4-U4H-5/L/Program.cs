using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete("Rodikliai.txt");

            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            const string finOne = "Knyga1.txt";
            const string finTwo = "Knyga2.txt";
            const string foutOne = "Rodikliai.txt";
            const string foutTwo = "ManoKnyga.txt";

            Dictionary<string,int> Answer = new Dictionary<string,int>();
            inOut.Repetitions(finOne, finTwo,punctuation,Answer);

            string longestSentenceOne = " ";
            string longestSentenceTwo = " ";
            int indexOne=0;
            int indexTwo=0;

            inOut.longestSentence(finOne, finTwo, punctuation, ref longestSentenceOne, ref indexOne, ref longestSentenceTwo, ref indexTwo);
            int WordCountOne = inOut.SplitIntoWordsAndCount(longestSentenceOne);
            int WordCountTwo = inOut.SplitIntoWordsAndCount(longestSentenceTwo);

            inOut.printAnswersPartOne(foutOne, Answer, longestSentenceOne, indexOne, longestSentenceTwo, indexTwo, WordCountOne, WordCountTwo);

            inOut.PrintUnifiedBook(punctuation, finOne, finTwo, foutTwo);
        }
    }
}
