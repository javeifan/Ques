using System;
using Ques.Collections;
using Ques.Tools;


namespace Ques
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = MathTool.getRandomInt(-5,25,10);
            HashTable ht = new HashTable();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(ht.Hash(i));
                ht[i] = i;
                Console.WriteLine(ht[i]);
            }
            
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
