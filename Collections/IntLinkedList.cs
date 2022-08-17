using System;
using System.Collections.Generic;
using System.Text;

namespace Ques.Collections
{
    class IntLinkedList
    {
        private class Node
        {
            public int Ele;
            public Node Next;

            public Node(int ele, Node next)
            {
                Ele = ele;
                Next = next;
            }
        }

        private Node First;
        private Node Last;
        private int Size=0;

        public void AddFirst(int ele)
        {
            First=new Node(ele, First);
            Size++;
        }
        public void RemoveFirst()
        {
            First = First.Next;
            if (Size!=0)
            {
                Size--;
            }
        }
        public int GetFirst()
        {
            if (Size!=0)
            {
                return First.Ele;
            }
            //先不考虑异常了
            return 0;
        }

        public int SizeOfLinkedList()
        {
            return Size;
        }
    }
}
