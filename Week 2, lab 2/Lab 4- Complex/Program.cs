using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4__Complex
{
    class Complex
    {
        public int x1, x2;
        public Complex() { }
        public Complex(int y1, int y2)
        {
            x1 = y1;
            x2 = y2;
        }
        public static Complex operator +(Complex a, Complex b)
        {
            Complex res = new Complex();
            res.x1 = a.x1 + b.x1;
            res.x2 = a.x2 + b.x2;

            return res;
        }
        public static Complex operator -(Complex a, Complex b)
        {
            Complex res = new Complex(a.x1 - b.x1, b.x2 - b.x2);
            return res;
        }
        public static Complex operator /(Complex a, Complex b)
        {
            Complex res = new Complex(a.x1 * b.x2, b.x1 * a.x2);
            return res;
        }
        public static Complex operator *(Complex a, Complex b)
        {
            Complex res = new Complex(a.x1 * b.x1, b.x2 * b.x2);
            return res;
        }

        public override string ToString()
        {
            return x1 + " " + x2;
        }

        }
}
