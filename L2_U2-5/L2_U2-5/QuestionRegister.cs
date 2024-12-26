using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_U2_5
{
    /// <summary>
    /// register for securely and privately storing the question data
    /// </summary>
    class QuestionRegister
    {
        public string facultyName {  get; set; }

        private List<Question> AllQuestions;

        /// <summary>
        /// constructor pivital for class creation
        /// </summary>
        public QuestionRegister()
        {
            AllQuestions = new List<Question>(); 
        }

        /// <summary>
        /// constructor pivital for class creation
        /// </summary>
        /// <param name="Questions"></param>
        public QuestionRegister(List<Question> Questions)
        {
            AllQuestions = new List<Question>();
            foreach(Question question in Questions)
            {
                this.AllQuestions.Add(question);
            }
        }

        /// <summary>
        /// adds data into the register while reading it in InOutUtils.cs
        /// </summary>
        /// <param name="question"></param>
        public void Add(Question question)
        {
            this.AllQuestions.Add(question);
        }
        /// <summary>
        /// tells the amount of questions
        /// </summary>
        /// <returns></returns>
        public int QuestionCount()
        {
            return this.AllQuestions.Count;
        }
        /// <summary>
        /// takes one instance of AllQuestions from the index the method receives
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Question QuestionByIndex(int index)
        {
            return this.AllQuestions[index];
        }
        /// <summary>
        /// checks (before adding) if the question already exists in the list
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public bool Contains(Question question)
        {
            return this.AllQuestions.Contains(question);
        }
        /// <summary>
        /// gets a list of unique authors
        /// </summary>
        /// <returns></returns>
        public List<string> GetUniqueAuthors()
        {
            List<string> Authors = new List<string>();
            foreach(Question question in this.AllQuestions)
            {
                string author = question.author;
                if(!Authors.Contains(author))
                {
                    Authors.Add(author);
                }
            }
            return Authors;
        }
        /// <summary>
        /// find how many times unique authors were mentioned in data set
        /// </summary>
        /// <param name="UniqueAuthors"></param>
        /// <returns></returns>

        public Dictionary<string,int> FindTimesMentioned(List<string> UniqueAuthors)
        {
            Dictionary<string, int> WinnerAuthorQuestionCount = new Dictionary<string, int>();
            
            foreach(string author in UniqueAuthors)
            {
                int count = 0;
                foreach (Question question in this.AllQuestions)
                {
                    if (question.author == author)
                    {
                        count++;
                    }
                }
                WinnerAuthorQuestionCount[author] = count;
            }
            return WinnerAuthorQuestionCount;
        }
        /// <summary>
        /// finds numbers of the highest mentioned author
        /// </summary>
        /// <param name="GroupOne"></param>
        /// <returns></returns>
        public int FindHighestMentionCount(Dictionary<string, int> GroupOne)
        {
            int count = 0;

            foreach (KeyValuePair<string, int> KVP in GroupOne)
            {
                string author = KVP.Key;
                int timesMentioned = KVP.Value;
                if(timesMentioned > count)
                {
                    count = timesMentioned;
                }
            }
            return count;
        }

        /// <summary>
        /// gets a list of the questions from data set
        /// </summary>
        /// <returns></returns>

        public List<string> getAllQuestions()
        {
            List<string> questionData = new List<string>();
            foreach (Question question in this.AllQuestions)
            {
                questionData.Add(question.question);
            }
            return questionData;
        }
        /// <summary>
        /// finds identical questions and puts them into a new list
        /// </summary>
        /// <param name="DataOne"></param>
        /// <param name="DataTwo"></param>
        /// <returns></returns>
        public List<string> FindIdenticalQuestions(List<string> DataOne, List<string> DataTwo)
        {
            List<string> IdenticalQuestions = new List<string>();
            foreach(string Question1 in DataOne)
            {
                foreach(string Question2 in DataTwo)
                {
                    if(Question1.Equals(Question2))
                    {
                        IdenticalQuestions.Add(Question1);
                    }
                }
            }
            return IdenticalQuestions;
        }

    }
}
