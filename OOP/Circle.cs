using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.OOP
{
    class Circle
    {
        public static double PI = 3.14;//precision
        public double r { get; set;}
        public double Area;

        public Circle(double r)
        {
            this.r = r;
        }

        public Circle()
        {
        }

        public double CalArea()
        {
            Area = PI * Math.Pow(r, 2);
            return Area;
        }
    }
}
