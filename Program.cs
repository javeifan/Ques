using System;
using Ques.Collections;
using Ques.OOP;//
using Ques.Tools;


namespace Ques
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now.ToLocalTime();
            int[] nums = {3, 4, 1, 5, 2, 6, 7, 9, 10};//you need to write a function to create a random. let's put it on hold for a while
            int[] nums1 = { 1, 5, 2, 4, 3 };
            int[] nums2 = MathTool.ReadSquareBracketsArray("[0,1,0,3,2,3]");

            TraverseArray(nums2);
            Console.WriteLine("max length is : " + E.LengthOfLongestIncreasingSubstring2(nums2));
            DateTime end = DateTime.Now.ToLocalTime();


            Console.WriteLine("运行时间："+end.AddMilliseconds(-1 * start.Millisecond).Millisecond + "ms");
        }

        static void  TraverseArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+ " ");
            }
            Console.WriteLine("");
        }

        
    }
}
