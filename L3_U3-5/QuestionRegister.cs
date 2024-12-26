using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_U3_5
{
    class QuestionRegister
    {
        
        public string studentAssosiationName {  get; set; }

        private QuestionContainer Register;
        /// <summary>
        /// Constructor for the register
        /// </summary>
        public QuestionRegister()
        {
            this.Register = new QuestionContainer();
        }
        /// <summary>
        /// call the container to receive - count
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.Register.count;
        }
        /// <summary>
        /// call the container to add a new question into the container
        /// </summary>
        /// <param name="question"></param>
        public void Add(Question question)
        {
           this.Register.Add(question);
        }
        /// <summary>
        /// call the container to receive a single data set
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Question Get(int index)
        {
            return this.Register.Get(index);
        }
        /// <summary>
        /// call the container to perform a check to not include duplicate data
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public bool Contains(Question question)
        {
            return this.Register.Contains(question);
        }
        /// <summary>
        /// call the container to put an element into the array
        /// </summary>
        /// <param name="index"></param>
        /// <param name="question"></param>
        public void Put(int index, Question question)
        {
            this.Register.Put(index, question);
        }
        /// <summary>
        /// call the container to insert an element into the array
        /// </summary>
        /// <param name="index"></param>
        /// <param name="question"></param>
        public void Insert(int index, Question question)
        {
            this.Register.Insert(index, question);
        }
        /// <summary>
        /// call the container to remove an element at a certain index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            this.Register.RemoveAt(index);
        }
        /// <summary>
        /// call the container to remove an element by certain conditions
        /// </summary>
        /// <param name="question"></param>
        public void Remove(Question question)
        {
            this.Register.Remove(question);
        }
        /// <summary>
        /// call the container to sort the array
        /// </summary>
        public void Sort()
        {
            this.Register.Sort();
        }
        /// <summary>
        /// unite the two seperate data bases into one register
        /// </summary>
        /// <param name="UnitedData"></param>
        public void AddToUnitedDataBase(QuestionRegister UnitedData)
        {
            for (int i = 0; i < Register.count; i++)
            {
                Question question = Register.Get(i);
                UnitedData.Add(question);
            }
        }



        /// <summary>
        /// returns a list of unique authors
        /// </summary>
        /// <returns></returns>
        public List<string> GetUniqueAuthors()
        {
            List<string> Authors = new List<string>();
            for (int i = 0; i < Register.count; i++)
            {
                Question question = Register.Get(i);
                string author = question.author;
                if (!Authors.Contains(author))
                {
                    Authors.Add(author);
                }
            }
            return Authors;
        }

        /// <summary>
        /// get a list of unique themes
        /// </summary>
        /// <param name="Themes"></param>
        public void FindThemeNames(List<string> Themes)
        {
            for (int i = 0; i < Register.count; i++)
            {
                Question question = Register.Get(i);
                string theme = question.theme;
                if(!Themes.Contains(theme))
                {
                    Themes.Add(theme);
                }
            }
        }

        /// <summary>
        /// finds the identical questions in the two data sets
        /// </summary>
        /// <param name="DataOne"></param>
        /// <param name="DataTwo"></param>
        /// <returns></returns>
        public QuestionRegister FindIdenticalQuestions(QuestionRegister DataOne, QuestionRegister DataTwo)
        {
            QuestionRegister IdenticalQuestions = new QuestionRegister();
            for (int i = 0; i < DataOne.Count(); i++)
            {
                Question question1 = DataOne.Get(i);
                for (int y = 0; y < DataTwo.Count(); y++)
                {
                    Question question2 = DataTwo.Get(y);
                    if (question1==question2)
                    {
                        IdenticalQuestions.Add(question1);
                        IdenticalQuestions.Add(question2);
                    }
                }
            }
            return IdenticalQuestions;
        }
        /// <summary>
        /// finds the hardest questions
        /// </summary>
        /// <param name="DataOne"></param>
        public void FindHardestQuestions(QuestionRegister DataOne)
        {
            for(int i = 0;i < Register.count;i++)
            {
                Question question = Register.Get(i);
                if (question.difficulty==3)
                {
                    DataOne.Add(question);
                }
            }
        }

        public void Sort()
        {
            for (int i = 0; i < this.count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < this.count; j++)
                {
                    if (this.Container[j].CompareTo(this.Container[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Question temp = this.Container[i];
                    this.Container[i] = this.Container[minIndex];
                    this.Container[minIndex] = temp;
                }
            }
        }

    }
}
