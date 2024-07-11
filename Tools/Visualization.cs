using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Tools
{
    class Visualization
    {
        public void showArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length - 1; i++)
            {

                Console.Write(array[i] + ",");
            }
            Console.Write(array[array.Length - 1] + "]\n");
        }
    }
}
