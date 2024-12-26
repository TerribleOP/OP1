// Edvinas Urbonas IFF4-6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_U1_5
{
    internal class TaskUtils
    {
        /// <summary>
        /// finds the hardest topic by returning a number corresponding to the hardest subject
        /// </summary>
        /// <param name="questions"></param>
        /// <returns>the hardest subject from the initial data set</returns>
        public static int DifficultyFind(List<Question> questions)
        {
            int mDiff = 0, aDiff = 0, lDiff = 0;

            foreach (Question question in questions)
            {
                if (question.Theme == "Math")
                {
                    mDiff += question.Difficulty;
                }
                if (question.Theme == "Art")
                {
                    aDiff += question.Difficulty;
                }
                if (question.Theme == "Literature")
                {
                    lDiff += question.Difficulty;
                }
            }

            if ((mDiff > aDiff) && (mDiff > lDiff))
            {
                return 1;
            }
            else if ((aDiff > mDiff) && (aDiff > lDiff))
            {
                return 2;
            }
            else if ((lDiff > aDiff) && (lDiff > mDiff))
            {
                return 3;
            }
            else if ((mDiff == aDiff))
            {
                return 4;
            }
            else if ((aDiff == lDiff))
            {
                return 5;
            }
            else if ((lDiff == mDiff)) 
            {
                return 6;
            }
            else if ((lDiff == mDiff && mDiff == lDiff)) 
            {
                return 7;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Finds the diffrent authors from the initial data
        /// </summary>
        /// <param name="questions"></param>
        /// <returns> List with unique authors</returns>
        public static List<string> FindAuthors(List<Question> questions)
        {
            List<string> Authors = new List<string>();

            foreach (Question question in questions)
            {
                string author = question.Author;
                if (!Authors.Contains(author))
                {
                    Authors.Add(author);
                }
            }
            return Authors;
        }
        /// <summary>
        /// finds how many times an author has been mentioned and stores it in an array corresponding with the author number
        /// </summary>
        /// <param name="Author"></param>
        /// <param name="questionNumber"></param>
        /// <param name="questions"></param>
        public static void FindTheAuthorMentioned(List<string> Author, int[] questionNumber, List<Question> questions)
        {
            for (int i = 0; i < Author.Count; i++)
            {
                foreach (Question question in questions)
                {
                    if (question.Author == Author[i])
                    {
                        questionNumber[i]++;
                    }
                }
            }
        }
        /// <summary>
        /// finds the author who has been mentioned the most along with how many times he/she was mentioned
        /// </summary>
        /// <param name="Author"></param>
        /// <param name="questionNumber"></param>
        /// <param name="questions"></param>
        /// <returns> the winning author and how many times he was mentioned</returns>
        public static (int winnerIndex, int maximum) FindTheAuthorWinner(List<string> Author, int[] questionNumber, List<Question> questions)
        {

            int maximum = 0, winnerIndex=0;
            for (int i = 0; i < Author.Count; i++)
            {
                if (questionNumber[i] > maximum)
                {
                    maximum = questionNumber[i];
                    winnerIndex = i;
                }

            }
            return (winnerIndex, maximum);
        }
        /// <summary>
        /// randomises 5 counts of the list of the original data, making sure to not repeat the same line of data twice
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="refinedQuestions"></param>
        public static void Randomise(List<Question> questions, List<Question> refinedQuestions)
        {
            Random rnd = new Random();
            int number;
            
            List<int> usedBefore = new List<int>();
            for (int i = 0; i < 5; i++) 
            {
                if (questions.Count < 5)
                {
                    number = rnd.Next(0, questions.Count);
                    refinedQuestions.Add(questions[number]);
                }
                else
                {
                    number = rnd.Next(0, 10);
                    if (!usedBefore.Contains(number))
                    {
                        refinedQuestions.Add(questions[number]);
                        usedBefore.Add(number);
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }
    }
}
