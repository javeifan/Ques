using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    public class ListNode
    {
        public int Ele { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int ele)
        {
            Ele = ele;
        }

        public ListNode(int ele, ListNode next) : this(ele)
        {
            Next = next;
        }

        public static ListNode CreateList(int[] array)
        {
            ListNode listNode = new ListNode(array[0]);
            ListNode headNode = listNode;//这里指向的不是listNode的地址 还是listNode所指向的那块内存
            for (int i = 1; i < array.Length; i++)
            {
                ListNode newNode = new ListNode(array[i]);
                listNode.Next = newNode;
                listNode = listNode.Next;
            }
            return headNode;
        }
    }
}
