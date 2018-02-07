using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace lab_3___mini_prime
{
    class Program
    {
        static bool isprime(string n)
        {
            int a = int.Parse(n);
            if (a == 1) return false;
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0) return false;

            }
            return true;
        }
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"C:\Users\Lenovo\Desktop\PP2\Week 2, lab 2\lab 3 - mini prime\input.txt");
            string[] a = line.Split(' ');

            string min = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (isprime(a[i]))
                {
                    if (int.Parse(a[i]) < int.Parse(min))
                    {
                        min = a[i];
                    }
                }
            }
            if (isprime(min))
            {
                File.WriteAllText(@"C:\Users\Lenovo\Desktop\PP2\Week 2, lab 2\lab 3 - mini prime\output.txt", min);

            }
        }
    }
}