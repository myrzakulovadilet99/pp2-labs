using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void mps(int[] r)
        {
            for (int i = 0; i < r.Length; i++)
            {
                if (r[i] == 1) r[i] = 0;
                for (int j = 2; j <= Math.Sqrt(r[i]); ++j)
                {
                    if (r[i] % j == 0)
                    {
                        r[i] = 0;
                    }
                }

            }


        }
        static void Main(string[] args)
        {
            
            
        }
    }
}