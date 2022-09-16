using System;
using Ques.Collections;
using System.Collections.Generic;
using Ques.Tools;
using System.Collections;


namespace Ques
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchAndSort.SortedTest();
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
                        max = Math.Max(max, j - i + 1);
                        i = k + 1;
                        break;
                    }
                }
                j++;
            }
            return Math.Max(max, j - i + 1);
        }

        static void  TraverseArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+ " ");
            }
            Console.WriteLine("");
        }

        static void TraverseList(ListNode listnode)
        {
            while (listnode != null)
            {
                Console.Write(listnode.Ele + " ");
                listnode = listnode.Next;
            }
            Console.WriteLine("");
        }
        
    }
}
