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
        public static bool f(int a)
        {
            int cnt = 0;
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                    cnt++;
            }
            if (cnt == 0)
                return true;
            return false;
        }

        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\Lenovo\Desktop\PP2\Week 2, lab 2\lab 3 - mini prime\input.txt");
            string[] arr = text.Split();
            int min = int.Parse(arr[0]);
            foreach (string s in arr)
            {
                int m = int.Parse(s);
                if (f(m))
                {
                    min = Math.Min(min, m);
                }
            }
            StreamWriter SW = new StreamWriter(@"C:\Users\Lenovo\Desktop\PP2\Week 2, lab 2\lab 3 - mini prime\output.txt");
            SW.WriteLine(min);
            SW.Close();

        }
    }
}
