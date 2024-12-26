using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_U3_5
{
    class QuestionContainer
    {
        private Question[] Container;

        public int count { get; private set; }

        private int capacity;
        /// <summary>
        /// constructor of the container
        /// </summary>
        /// <param name="capacity"></param>
        public QuestionContainer(int capacity = 16)
        {
            this.capacity = capacity;
            this.Container = new Question[capacity];
        }
        /// <summary>
        /// ensures the dynamic capacity of the array
        /// </summary>
        /// <param name="minimumCapacity"></param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.capacity)
            {
                Question[] temp = new Question[minimumCapacity];
                for (int i = 0; i < this.count; i++)
                {
                    temp[i] = this.Container[i];
                }
                this.capacity = minimumCapacity;
                this.Container = temp;
            }
        }
        /// <summary>
        /// performs a capacity check, then adds a new question into the container
        /// </summary>
        /// <param name="question"></param>
        public void Add(Question question)
        {
            if (this.count == this.capacity)
            {
                EnsureCapacity(this.capacity * 2);
            }
            this.Container[this.count++] = question;
        }
        /// <summary>
        /// returns a single data set from the array
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Question Get(int index)
        {
            return this.Container[index];
        }
        /// <summary>
        /// performs a check to not include duplicate data
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public bool Contains(Question question)
        {
            return this.Container.Contains(question);
        }
        /// <summary>
        /// puts an element into the array
        /// </summary>
        /// <param name="index"></param>
        /// <param name="question"></param>
        public void Put(int index, Question question)
        {
            this.Container[index] = question;
        }
        /// <summary>
        /// inserts an element into the array
        /// </summary>
        /// <param name="index"></param>
        /// <param name="question"></param>
        public void Insert(int index, Question question)
        {
            if (this.count == this.capacity)
            {
                EnsureCapacity(this.capacity * 2);
            }
            for (int i = this.count - 1; i >= index; i--)
            {
                this.Container[i+1]=this.Container[i];
            }
            this.Container[index]=question;
            this.count++;
        }
        /// <summary>
        /// removes an element at a certain index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            for(int i = index; i< this.count-1;i++)
            {
                this.Container[i] = this.Container[i+1];
            }
            this.Container[this.count-1]=null;
            this.count--;
        }
        /// <summary>
        /// removes an element by certain conditions
        /// </summary>
        /// <param name="question"></param>
        public void Remove(Question question)
        {
            int index = -1;
            for (int i = 0; i < this.count; i++)
            {
                if (this.Container[i].Equals(question))
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                RemoveAt(index);
            }
        }
        /// <summary>
        /// sorts the container with a selection sort
        /// </summary>
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
