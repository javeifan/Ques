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
            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            dic.Add(1,true);
            Console.WriteLine(dic[1]);
            Console.WriteLine(dic.ContainsKey(2));
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
