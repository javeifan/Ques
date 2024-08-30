using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Algorithms
{
    class TestInput
    {
        public static int[] getRandomInt(int lowerBound, int higherBound, int length)//Open interval开区间
        {
            //1.Critical cases
            if (lowerBound > higherBound)
            {
                throw new Exception("lowerBound must be lower than higherBound");
            }
            if (length > higherBound - lowerBound + 1)
            {
                throw new Exception("The number of integers between lower and higher bound is not enough");
            }
            //2.Main function 
            int[] nums = new int[length];
            Random random = new Random();
            //2.1.Create a number list between lower and higher bound.
            List<int> numberList = new List<int>();
            int range = higherBound - lowerBound + 1;
            for (int i = 0; i < higherBound - lowerBound + 1; i++)
            {
                numberList.Add(lowerBound + i);
            }
            //2.2.Pick random one of the numberList to make sure the numbers are not repeated.
            for (int i = 0; i < length; i++)
            {
                int index = random.Next() % (numberList.Count);
                int num = numberList[index];
                numberList.RemoveAt(index);
                nums[i] = num;
            }
            return nums;
        }

        public static int[] GetRandomPokers()
        {
            return getRandomInt(1, 52, 52);
        }

        public static int[] GetReverseInts(int N)
        {
            int[] ints = new int[N];
            for (int i = 0; i < N; i++)
            {
                ints[i] = N - i;
            }
            return ints;
        }

        /// <summary>
        /// N = The range of the numbers the array contains. e.g. N = 2, the array only contains 0,1. e.g. [0,0,1,0,1]
        /// </summary>
        /// <returns></returns>
        public static int[] GetRandomIntsInRange(int N, int length)
        {
            int[] ints = new int[length];
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                ints[i] = rand.Next() % N;
            }
            return ints;
        }
    }
}
