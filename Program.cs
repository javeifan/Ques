using System;
using Ques.Collections;


namespace Ques
{
    class Program
    {
        static void Main(string[] args)
        {
            testQ155();
        }

        static void  TraverseArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static void testQ1S1(Easy easy)
        {
            int[] nums1 = { 2, 7, 11, 15 };
            int[] nums2 = { 3,2,4 };
            int[] nums3 = { 3,3 };
            TraverseArray(easy.Q1TwoSum1(nums1,9));
            TraverseArray(easy.Q1TwoSum1(nums2,6));
            TraverseArray(easy.Q1TwoSum1(nums3,6));
            Console.WriteLine("----split line----");
            TraverseArray(easy.Q1TwoSum2(nums1,9));
            TraverseArray(easy.Q1TwoSum2(nums2,6));
            TraverseArray(easy.Q1TwoSum2(nums3,6));
        }

        static void testQ155()
        {
            MinStack minstack = new MinStack();
            minstack.push(4);
            minstack.push(3);
            minstack.push(2);
            minstack.push(1);
            Console.WriteLine("the min is " + minstack.Min());
            Console.WriteLine(minstack.Pop());
            Console.WriteLine("the min is "+minstack.Min());
            Console.WriteLine(minstack.Pop());
            Console.WriteLine("the min is " + minstack.Min());
            Console.WriteLine(minstack.Pop());
            Console.WriteLine("the min is " + minstack.Min());
            Console.WriteLine(minstack.Pop());
        }
    }
}
