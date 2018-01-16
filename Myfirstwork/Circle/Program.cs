using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Circle
    {
        public double r;
        public Circle(double R)
        {
            r = R;
        }
        public double A()
        {
            return Math.PI * r * r;
            // площадь круга
        }
        public double D()
        {
            return 2 * r;
            // диаметр круга
        }
        public double Circum()
        {
            return Math.PI * r;
            // окружность круга
        }
        public double Area { get { return this.A(); } }
        public double Diametr { get { return this.D(); } }
        public double Circumference
        {
            get { return this.Circum(); }
        }
    }

       
    class Program
    {
         public static double Area { get; private set; }
         public static double Diametr { get; private set; }
         public static double Circumference { get; private set; }
        static void Main(string[] args) 
        {
                double r = double.Parse(Console.ReadLine());

                Circle circle = new Circle(r);
                Console.WriteLine(circle.Area);
                Console.WriteLine(circle.Diametr);
                Console.WriteLine(circle.Circumference);
                Console.ReadKey();
                


        }
    }
}
