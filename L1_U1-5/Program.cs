// Edvinas Urbonas IFF4-6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_U1_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> questions = InOutUtils.ReadQuestions(@"Questions.csv"); 

            InOutUtils.PrintInitialData(questions);

            int difficultyMax = TaskUtils.DifficultyFind(questions); 

            List<string> Author = TaskUtils.FindAuthors(questions); 
            int[] questionNumber = new int[Author.Count()];

            TaskUtils.FindTheAuthorMentioned(Author, questionNumber, questions);
            (int winnerIndex, int winnerPoints ) = TaskUtils.FindTheAuthorWinner(Author,questionNumber,questions); 

            List<Question> refinedQuestions = new List<Question>();
            TaskUtils.Randomise(questions, refinedQuestions); 


            InOutUtils.PrintQuestions(questions, difficultyMax, Author, winnerIndex, winnerPoints, refinedQuestions);

        }
    }
}
