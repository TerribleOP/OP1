using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics.Tracing;


namespace L
{
    class inOut
    {
        /// <summary>
        /// places 10 words that are in the first data set and not in the second data set into a dictionary variable along with how many times the word was encountered
        /// </summary>
        /// <param name="finOne"></param>
        /// <param name="finTwo"></param>
        /// <param name="punctuation"></param>
        /// <param name="Answer"></param>
        public static void Repetitions(string finOne, string finTwo, char[] punctuation, Dictionary<string, int> Answer)
        {
            string lineOne;
            string lineTwo;
            int count = 0;
            using (StreamReader readerOne = new StreamReader(finOne, Encoding.UTF8))
            {
                while ((lineOne = readerOne.ReadLine()) != null)
                {
                    string[] wordsOne = lineOne.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string wordOne in wordsOne)
                    {
                        string normalisedWordOne = wordOne.ToLower();
                        bool foundInKnyga2 = false;

                        using (StreamReader readerTwo = new StreamReader(finTwo, Encoding.UTF8))
                        {
                            while ((lineTwo = readerTwo.ReadLine()) != null)
                            {
                                string[] wordsTwo = lineTwo.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string wordTwo in wordsTwo)
                                {
                                    string normalisedWordTwo = wordTwo.ToLower();
                                    if (normalisedWordOne == normalisedWordTwo)
                                    {
                                        foundInKnyga2 = true;
                                        break;
                                    }
                                }
                                if (foundInKnyga2) break;
                            }
                        }
                        if (!foundInKnyga2)
                        {
                            if (Answer.ContainsKey(normalisedWordOne))
                            {
                                Answer[normalisedWordOne]++;
                            }
                            else
                            {
                                if (count < 10)
                                {
                                    Answer[normalisedWordOne] = 1;
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// finds the longest sentence in each file and puts it into a <ref> variable
        /// </summary>
        /// <param name="finOne"></param>
        /// <param name="finTwo"></param>
        /// <param name="punctuation"></param>
        /// <param name="longestSentenceOne"></param>
        /// <param name="indexOne"></param>
        /// <param name="LongestSentenceTwo"></param>
        /// <param name="IndexTwo"></param>
        public static void longestSentence(string finOne, string finTwo, char[] punctuation, ref string longestSentenceOne, ref int indexOne, ref string LongestSentenceTwo, ref int IndexTwo)
        {
            string lineOne;
            string lineTwo;
            int length = 0;
            string pattern = @"[^.!?]*[.!?]";
            
            using (StreamReader readerOne = new StreamReader(finOne, Encoding.UTF8))
            {
                int currentLineIndex = 0;
                while ((lineOne = readerOne.ReadLine()) != null)
                {
                    MatchCollection matches = Regex.Matches(lineOne, pattern);
                    foreach (Match match in matches)
                    {
                        string temp = match.Value.Trim();
                        if(temp.Length > length)
                        {
                            length = temp.Length;
                            longestSentenceOne = temp;
                            indexOne = currentLineIndex;
                        }
                    }
                    currentLineIndex++;
                }
                
            }
            using (StreamReader readerTwo = new StreamReader(finTwo, Encoding.UTF8))
            {
                int currentLineIndex = 0;
                while ((lineTwo = readerTwo.ReadLine()) != null)
                {
                    MatchCollection matches = Regex.Matches(lineTwo, pattern);
                    foreach (Match match in matches)
                    {
                        string temp = match.Value.Trim();
                        if (temp.Length > length)
                        {
                            length = temp.Length;
                            LongestSentenceTwo = temp;
                            IndexTwo = currentLineIndex;
                        }
                    }
                    currentLineIndex++;
                }
                
            }
        }
        /// <summary>
        /// splits the longest sentence into words
        /// </summary>
        /// <param name="sentance"></param>
        /// <returns></returns>
        public static int SplitIntoWordsAndCount(string sentance)
        {
            char[] nonSentenceEndingPunctuation = { ' ', ',', ';', ':', '-', '(', ')', '[', ']', '{', '}', '\'', '"', '/', '\\'};
            string[] values = sentance.Split(nonSentenceEndingPunctuation, StringSplitOptions.RemoveEmptyEntries);
            return values.Length;
        }
        /// <summary>
        /// prints the answers of the first part of the task into a .txt file
        /// </summary>
        /// <param name="fout"></param>
        /// <param name="Answer"></param>
        /// <param name="longestSentenceOne"></param>
        /// <param name="indexOne"></param>
        /// <param name="longestSentenceTwo"></param>
        /// <param name="indexTwo"></param>
        /// <param name="WordCountOne"></param>
        /// <param name="WordCountTwo"></param>
        public static void printAnswersPartOne(string fout, Dictionary<string,int> Answer, string longestSentenceOne, int indexOne, string longestSentenceTwo, int indexTwo, int WordCountOne, int WordCountTwo)
        {
            var sortedAnswer = Answer
                .OrderByDescending(pair => pair.Value)
                .ThenBy(pair => pair.Key)
                .ToList();

            File.AppendAllText(fout, "Surikiuoti nepasikartojantys žodžiai:\n");
            foreach (var pair in sortedAnswer)
            {
                string temp = string.Format($"Žodis: {pair.Key}, Kiekis: {pair.Value}\n");
                File.AppendAllText(fout, temp);
            }
            File.AppendAllText(fout, "\n");

            File.AppendAllText(fout, $"Ilgiausias sakinys: {longestSentenceOne}\n");
            File.AppendAllText(fout, $"Eilės indeksas: {indexOne + 1}\n");
            File.AppendAllText(fout, $"Žodžių kiekis: {WordCountOne}\n");
            File.AppendAllText(fout, $"Simbolių kiekis: {longestSentenceOne.Length}\n");
            File.AppendAllText(fout, "\n");
            File.AppendAllText(fout, $"Ilgiausias sakinys: {longestSentenceTwo}\n");
            File.AppendAllText(fout, $"Eilės indeksas: {indexTwo + 1}\n");
            File.AppendAllText(fout, $"Žodžiu kiekis: {WordCountTwo}\n");
            File.AppendAllText(fout, $"Simboliu kiekis: {longestSentenceTwo.Length}\n");
        }
        /// <summary>
        /// calculates and prints the unified book system into an .txt file
        /// </summary>
        /// <param name="punctuation"></param>
        /// <param name="finOne"></param>
        /// <param name="finTwo"></param>
        /// <param name="fout"></param>
        public static void PrintUnifiedBook(char[] punctuation, string finOne, string finTwo, string fout)
        {
            string TextOne = File.ReadAllText(finOne);
            string TextTwo = File.ReadAllText(finTwo);

            //string[] DataOne = TextOne.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            //string[] DataTwo = TextTwo.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);

            string[] DataOne = TextOne.Split(' ');
            string[] DataTwo = TextTwo.Split(' ');

            var result = new System.Text.StringBuilder();

            int indexOne = 0, indexTwo = 0;
            bool readFromFirst = true;


            while (indexOne > DataOne.Length || indexTwo > DataTwo.Length)
            {
                if (readFromFirst)
                {
                    bool foundMatch = false;
                    for (int i = indexOne; i < DataOne.Length; i++)
                    {
                        if (indexTwo < DataTwo.Length && DataOne[i].ToLower() == DataTwo[indexTwo].ToLower())
                        {
                            indexOne = i + 1;
                            readFromFirst = false;
                            foundMatch = true;
                            break;
                        }
                        result.Append(DataOne[i] + " ");
                        indexOne = i + 1;
                    }
                    if (!foundMatch) indexOne = DataOne.Length;
                }
                else
                {
                    bool foundMatch = false;
                    for (int i = indexTwo; i < DataTwo.Length; i++)
                    {
                        if (indexOne < DataOne.Length && DataTwo[i].ToLower() == DataOne[indexOne].ToLower())
                        {
                            indexTwo = i + 1;
                            readFromFirst = true;
                            foundMatch = true;
                            break;
                        }
                        result.Append(DataTwo[i] + " ");
                        indexTwo = i + 1;
                    }
                    if (!foundMatch) indexTwo = DataTwo.Length;
                }
            }
            while (indexOne < DataOne.Length)
            {
                result.Append(DataOne[indexOne++] + " ");
            }
            while (indexTwo < DataTwo.Length)
            {
                result.Append(DataTwo[indexTwo++] + " ");
            }
            File.WriteAllText(fout, result.ToString().Trim());
        }
    }
}
