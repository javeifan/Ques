using System;
using Ques.Collections;
using System.Collections.Generic;
using Ques.Tools;
using System.Collections;
using System.Text;
using Ques.BeginningCS;
using Ques.Mathemaitcs;
using Ques.Algorithms;
using Ques.Algorithms.Collections;

namespace Ques
{
    class Program
    {
        static void Main(string[] args)
        {
            Ques.Algorithms.Collections.LinkedStack<int> stack = new LinkedStack<int>();
            
        }

        public static int Sum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            char[] chars = s.ToCharArray();
            int l = s.Length;
            int i = 0;
            int j = 0;
            int max = 0;
            while (i < l && j < l - 1)
            {//要保证不能越界
                for (int k = i; k <= j; k++)
                {
                    if (chars[k] == chars[j + 1])
                    {
                        max = System.Math.Max(max, j - i + 1);
                        i = k + 1;
                        break;
                    }
                }
                j++;
            }
            return System.Math.Max(max, j - i + 1);
        }

        static void TraverseArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("");
        }
        static void showArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("");
        }

        static void TraverseList()
        {

        }

        static void TraverseListNode(ListNode listnode)
        {
            while (listnode != null)
            {
                Console.Write(listnode.val + " ");
                listnode = listnode.next;
            }
            Console.WriteLine("");
        }


        static void TraverseTrack(IList<IList<int>> track)
        {
            for (int i = 0; i < track.Count; i++)
            {
                TraverseList();
            }

        }
        
    }
}
