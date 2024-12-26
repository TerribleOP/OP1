using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3._4
{
    class StudentContainer
    {
        private Student[] Students;
        public int count { get; private set; }

        private int capacity;

        public StudentContainer(int capacity = 16)
        {
            this.Students = new Student[capacity];
        }

        public StudentContainer(StudentContainer container) : this()
        {
            for (int i = 0; i < container.count; i++)
            {
                this.Add(container.Get(i));
            }
        }


        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.capacity)
            {
                Student[] temp = new Student[minimumCapacity];
                for (int i = 0; i < this.count; i++)
                {
                    temp[i] = this.Students[i];
                }
                this.capacity = minimumCapacity;
                this.Students = temp;
            }
        }

        public void Add(Student student)
        {
            if (this.count == this.capacity)
            {
                EnsureCapacity(this.capacity * 2);
            }
            this.Students[this.count++] = student;
        }

        public Student Get(int index)
        {
            return this.Students[index];
        }

        public bool Contains(Student student)
        {
            return this.Students.Contains(student);
        }

        public void Put(int index, Student student)
        {
            this.Students[index] = student;
        }

        public void Insert(int index, Student student)
        {
            if (this.count == this.capacity)
            {
                EnsureCapacity(this.capacity * 2);
            }

            for (int i = this.count - 1; i >= index; i--)
            {
                this.Students[i + 1] = this.Students[i];
            }
            this.Students[index] = student;
            this.count++;
        }

        public void Remove(Student student)
        {
            int index = -1;
            for (int i = 0; i < this.count; i++)
            {
                if (this.Students[i].Equals(student))
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.count - 1; i++)
            {
                this.Students[i] = this.Students[i + 1];
            }
            this.Students[this.count - 1] = null;
            this.count--;
        }

        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.count-1; i++)
                {
                    Student a = this.Students[i];
                    Student b = this.Students[i + 1];
                    if (a.CompareTo(b) < 0)
                    {
                        this.Students[i] = b;
                        this.Students[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
