using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzduotis01
{
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }

        //public Student(string name, int grade, int age)
        //{
        //    Name = name;
        //    Grade = grade;
        //    Age = age;
        //}

        public override string ToString()
        {
            return $"{Name}, Grade: {Grade}, ({Age} y.o.)";
        }
    }
}
