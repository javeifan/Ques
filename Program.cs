using System;
using Ques.Collections;
using Ques.Tools;


namespace Ques
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 2, 1 };
            ListNode head = ListNode.CreateList(array);
            E.IsPalindrome(head);
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
