using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace seria
{
    [Serializable]
    public class Complex
    {
        public int a, b;
        public Complex()
        {

        }
        public Complex(int _a, int _b)
        {
            a = _a;
            b = _b;
        }
        public override string ToString()
        {
            return a + "/" + b;
        }
        public Complex Add(Complex complex2)
        {
            Complex c = new Complex(this.a * complex2.b + this.b * complex2.a, this.b * complex2.b);
            return c;
        }
        public Complex Minus(Complex complex2)
        {
            Complex c = new Complex(this.a * complex2.b - this.b * complex2.a, this.b * complex2.b);
            return c;
        }
        public Complex Multiple(Complex complex2)
        {
            Complex c = new Complex(this.a * complex2.a, this.b * complex2.b);
            return c;
        }
        public Complex Div(Complex complex2)
        {
            Complex c = new Complex(this.a * complex2.b, this.b * complex2.a);
            return c;
        }
        public void Simplify()
        {
            int _a = this.a;
            int _b = this.b;
            while (_a > 0 && _b > 0)
            {
                if (_a > _b)
                {
                    _a %= _b;
                }
                else
                {
                    _b %= _a;
                }
            }
            int gcd = _a + _b;
            a /= gcd;
            b /= gcd;
        }
    }
    class Program
    {
        static void F(Complex t3)
        {
            BinaryFormatter xs = new BinaryFormatter();
            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, t3);
            fs.Close();
        }
        static void F1()
        {
            BinaryFormatter xs = new BinaryFormatter();
            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Complex t3 = xs.Deserialize(fs) as Complex;
            Console.WriteLine("Desirilized element1 are : " + t3);
        }
        static void F2(Complex t4)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream fs = new FileStream("ser.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, t4);
            fs.Close();
        }
        static void F3()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream fs = new FileStream("ser.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Complex t4 = xs.Deserialize(fs) as Complex;
            Console.WriteLine("Desirilized element2 are : " + t4);
        }
        static void Main(string[] args)
        {
            string l = Console.ReadLine();
            string[] n = l.Split(' ');
            string[] j = n[0].Split('/');
            string[] k = n[1].Split('/');

            int a1 = int.Parse(j[0]);
            int a2 = int.Parse(j[1]);
            int b1 = int.Parse(k[0]);
            int b2 = int.Parse(k[1]);

            Complex t1 = new Complex(a1, a2);
            Complex t2 = new Complex(b1, b2);

            Complex t3 = t1.Add(t2);
            t3.Simplify();
            Complex t4 = t1.Minus(t2);
            t4.Simplify();
            Complex t5 = t1.Multiple(t2);
            t5.Simplify();
            Complex t6 = t1.Div(t2);
            t6.Simplify();

            F(t3);
            F1();
            F2(t4);
            F3();

            Console.WriteLine("Sum = " + t3);
            Console.WriteLine("Subtract = " + t4);
            Console.WriteLine("Product = " + t5);
            Console.WriteLine("Division = " + t6);
            Console.ReadKey();
        }
    }
}