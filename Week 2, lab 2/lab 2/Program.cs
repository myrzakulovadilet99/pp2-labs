using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Week_2__lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\Lenovo\Desktop\PP2\Week 2, lab 2\Week 2, lab 2\lab2.txt");
            string[] arr = text.Split();
            int max = int.Parse(arr[0]);
            int min = int.Parse(arr[0]);
            foreach(string a in args)
            {
                int s = int.Parse(a);
                max = Math.Max(max, s);
                min = Math.Min(min, s);
            }
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.ReadKey();
        }

    }
}
