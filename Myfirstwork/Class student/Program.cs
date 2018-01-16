using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_student
{
    class student
    {
        public string Surname;
        public string Name;
        public int Age;
        public float Gpa;

        public student ()
        {
            Surname = "Myrzakulov";
            Name = "Adilet";
            Age = 18;
            Gpa = 3;

        } 

         public student(string surname, string name, int age, float gpa)
        {
            Surname = surname;
            Name = name;
            Age = age;
            Gpa = gpa;
        }
       
        public override string ToString()
        {
            return Surname + " " + Name + " " + Age + " " + Gpa;

        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            student s = new student();
            s.Name = "Adik";
            Console.WriteLine(s);

            Console.ReadKey();


        }
    }
}
