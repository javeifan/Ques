using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Tools
{
    public class MathTool
    {
        public static int[] getRandomInt(int lowerBound,int higherBound,int length)//Open interval开区间
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
            for (int i = 0; i < higherBound-lowerBound+1; i++)
            {
                numberList.Add(lowerBound+i);
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

        public static int[] ReadSquareBracketsArray(string array)
        {
            array = array.Replace("[", "");
            array = array.Replace("]", "");
            string[] arrayStr = array.Split(',');
            int[] resultArray = new int[arrayStr.Length];
            for (int i = 0; i < arrayStr.Length; i++)
            {
                resultArray[i] = Convert.ToInt32(arrayStr[i]);
            }
            return resultArray;
        }

        public static int Sum_ProportionalSequence(int basement, int index)//index表示指数
        {
            //this calculate like 1 + 2^1 + 2^2 + 2^3 + 2^4...
            return Convert.ToInt32( Math.Pow(basement,index+1)) - 1;
        }

        public static int GetNextPrimeNumber(int currentPrimeNumber)
        {
            return 1;
        }
    }
}
