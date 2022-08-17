using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    public class ListNode
    {
        private int Ele { get; set; }
        private ListNode Next { get; set; }

        public ListNode(int ele)
        {
            Ele = ele;
        }

        public ListNode CreateList(int[] array)
        {
            ListNode listNode = new ListNode(array[0]);
            ListNode headNode = listNode;
            for (int i = 0; i < array.Length; i++)
            {
                ListNode newNode = new ListNode(array[i]);
                listNode.Next = newNode;
                listNode = listNode.Next;
            }
            return null;
        }
    }
}
