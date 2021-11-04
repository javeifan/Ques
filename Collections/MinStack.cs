using System;
using System.Collections.Generic;
using System.Text;

namespace Ques.Collections
{
    // this class is created to be a solution of Q155 Min Stack
    class MinStack
    {
        private IntLinkedList ValueList=new IntLinkedList();
        private IntLinkedList MinList=new IntLinkedList();


        public bool push(int ele)
        {
            ValueList.AddFirst(ele);
            if (MinList.SizeOfLinkedList()!=0 && ele<MinList.GetFirst())
            {
                MinList.AddFirst(ele);
            }
            else if(MinList.SizeOfLinkedList()==0)
            {
                MinList.AddFirst(ele);
            }
            else
            {
                MinList.AddFirst(MinList.GetFirst());
            }
            return true;
        }

        public int Pop()
        {
            if (ValueList.SizeOfLinkedList()!=0)
            {
                int first = ValueList.GetFirst();
                ValueList.RemoveFirst();
                MinList.RemoveFirst();
                return first;
            }
            throw new Exception("the stack is empty");
        }

        public int Top()
        {
            return ValueList.SizeOfLinkedList();
        }

        public int Min()
        {
            if (ValueList.SizeOfLinkedList()!=0)
            {
                return MinList.GetFirst();
            }

            throw new Exception("the stack is empty");
        }
    }
}
