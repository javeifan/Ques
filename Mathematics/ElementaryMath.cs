using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Mathemaitcs
{
    class ElementaryMath
    {
        double e = 0;

        /*here we can't achieve tru infinite loops so
         * there should be a stop indicator
         * 1.difference between the results of two iterations
         * 2.Number of decimal digits
         * 3.number of loop
         */
        public static double CompoundInterestLimit(double annualInterestRate, int num_loop)
        {
            double product = 1.0;
            for (int i = 0; i < num_loop; i++)
            {
                product = product * (1.0 + annualInterestRate / num_loop);
            }
            return product;
        }
    }
}
