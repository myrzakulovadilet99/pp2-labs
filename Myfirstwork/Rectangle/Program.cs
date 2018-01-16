using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rectangle
    {
        public int A;
        public int B;
        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }
        public void Writeab()
        {

            Console.WriteLine("Длина A={0}", A);
            Console.WriteLine("Длина B={0}", B);

            // для вывода сторон на экран
        }
        public int P()
        {
            return A * 2 + B * 2;
            // perimetr
        }
        public int S()
        {
            return A * B;
            // Area
        }
        public int Perimetr{ get { return this.P(); } }
        public int Area { get { return this.S(); } }
        
       }
    class Program
    {
        public static int Perimetr { get; private set; }
        public static int Area { get; private set; }
        static void Main(string[] args)
        {
            int A = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(A, B);
                Console.WriteLine(rectangle.Perimetr);
                Console.WriteLine(rectangle.Area);
                Console.ReadKey();

        }
    }
}
