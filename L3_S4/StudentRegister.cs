using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4
{
    class StudentRegister
    {
        public string facultyname { get; set; }

        private StudentContainer register;

        public StudentRegister()
        {
            register = new StudentContainer();
        }

        public Student Get(int index)
        {
            return register.Get(index);
        }

        public bool Contains(Student student)
        {
            return this.register.Contains(student);
        }

        public void Add(Student student)
        {
            this.register.Add(student);
        }

        public int Count()
        {
            return this.register.count;
        }

        public void Sort()
        {
            this.register.Sort();
        }

    }
}
