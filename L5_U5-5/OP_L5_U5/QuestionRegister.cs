using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_L5_U5
{
    class QuestionRegister
    {
        public string studentAssosiationName { get; set; }

        private List<Question> Register;
        /// <summary>
        /// Constructor
        /// </summary>
        public QuestionRegister() 
        { 
            Register = new List<Question>();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public QuestionRegister(List<Question> Register)
        {
            Register = new List<Question>();
            foreach (var item in Register)
            {
                this.Register.Add(item);
            }
        }
        /// <summary>
        /// Adds element to list
        /// </summary>
        /// <param name="question"></param>
        public void Add(Question question)
        {
            this.Register.Add(question);
        }
        /// <summary>
        /// returns the amount of elements in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.Register.Count;
        }
        /// <summary>
        /// returns one instance of the element
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Question Get(int index)
        {
            return this.Register[index];
        }
        /// <summary>
        /// checks whether list already contains element
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public bool Contains(Question question)
        {
            return this.Register.Contains(question);
        }
        /// <summary>
        /// puts an author into a list<string> if it that instance isn't there already
        /// </summary>
        /// <param name="Authors"></param>
        public void CheckForUniqueAuthors(List<string> Authors)
        {
            foreach (Question item in Register)
            {
                if (!Authors.Contains(item.author))
                {
                    Authors.Add(item.author);
                }
            }
        }
        /// <summary>
        /// finds the highest mentioned author along with how many times he found (by reference)
        /// </summary>
        /// <param name="Authors"></param>
        /// <param name="count"></param>
        /// <param name="highestauthor"></param>
        public void HighestCount(List<string> Authors, ref int count, ref string highestauthor)
        {
            int highest = count;
            foreach (string author in Authors)
            {
                int localCount = 0;
                foreach (Question question in Register)
                {
                    if (string.Equals(question.author, author, StringComparison.OrdinalIgnoreCase))
                    {
                        localCount++;
                    }
                }
                if (localCount > highest)
                {
                    highest = localCount;
                    highestauthor = author;
                }
            }
            count = highest;
        }
        /// <summary>
        /// puts an author into a list<string> if it that instance isn't there already and he created a musical type question
        /// </summary>
        /// <param name="Authors"></param>
        public void CheckForUniqueMusicQuestionAuthors(List<string> Authors)
        {
            foreach (Question question in Register)
            {
                if (!Authors.Contains(question.author) && question.type == "musical")
                {
                    Authors.Add(question.author);
                }
            }
        }
        /// <summary>
        /// finds the highest mentioned musical question author along with how many times he found (by reference)
        /// </summary>
        /// <param name="Authors"></param>
        /// <param name="count"></param>
        /// <param name="highestauthor"></param>
        public void HighestMusicalCount(List<string> Authors, ref int count, ref string highestauthor)
        {
            int highest = count;
            foreach (string author in Authors)
            {
                int localCount = 0;
                foreach (Question question in Register)
                {
                    if (string.Equals(question.author, author, StringComparison.OrdinalIgnoreCase) && question.type=="musical")
                    {
                        localCount++;
                    }
                }
                if (localCount > highest)
                {
                    highest = localCount;
                    highestauthor = author;
                }
            }
            count = highest;
        }
        /// <summary>
        /// adds elements to new register, used to unite registers
        /// </summary>
        /// <param name="UnitedData"></param>
        public void AddToUnitedDataBase(QuestionRegister UnitedData)
        {
            foreach (Question question in Register)
            {
                UnitedData.Add(question);
            }

        }
        /// <summary>
        /// sorts by theme and then by difficulty in DESCENDING order
        /// </summary>
        /// <param name="comparator"></param>
        public void Sort(QuestionComparitor comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < Register.Count - 1; i++)
                {
                    Question a = this.Register[i];
                    Question b = this.Register[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.Register[i] = b;
                        this.Register[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        /// <summary>
        /// finds all the unique questions which themes are history
        /// </summary>
        /// <returns></returns>
        public QuestionRegister FindHistoryThemeQuestions()
        {
            QuestionRegister result = new QuestionRegister();

            foreach (Question question in Register)
            {
                if (question.theme == "History")
                {
                    result.Add(question);
                }
            }
            return result;

        }

    }
}
