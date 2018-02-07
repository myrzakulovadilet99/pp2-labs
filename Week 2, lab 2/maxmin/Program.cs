using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace maxmin
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"C:\Users\Lenovo\Desktop\PP2\Week 2, lab 2\maxmin\minmax.txt");
            string[] a = line.Split();
            int max = int.Parse(a[0]);
            int min = int.Parse(a[0]);
            foreach (string k in args)
            {
                int s = int.Parse(k);
                max = Math.Max(max, s);
                min = Math.Min(min, s);
            }
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.ReadKey();
        }

    }
}

