using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ques.Algorithms.Collections
{
  
    class LinkedStack<Item> : IEnumerable
    {
        private Node<Item> first {get; set;}
        private int N {get; set;}

        public bool IsEmpty()
        {
            return first == null;//remember this concise, terse and brief
        }

        public Item Pop()//This is not safe
        {
            Node<Item> _first = first;
            first = first.next;
            N--;
            return _first.item;
        }

        public void Push(Item item)
        {
            Node<Item> newFirst = new Node<Item>();
            newFirst.item = item;
            newFirst.next = first;
            first = newFirst;
            N++;
        }

        public Item Peek()
        {
            return first.item;
        }

        public int Size()
        {
            return N;
        }

        public LinkedStack<Item> Copy()
        {
            LinkedStack<Item> newStack = new LinkedStack<Item>();
            int count = 0;
            foreach (Item item in this)
            {
                this.Push(item);
                count++;
            }
            for (int i = 0; i < count; i++)
            {
                newStack.Push(this.Pop());
            }
            
            return newStack;
        }

        public IEnumerator GetEnumerator()
        {
            return new StackIEnumerator(this);
        }

        private class StackIEnumerator : IEnumerator
        {
            //Concise syntax. Show it's a read-only attributes.
            //核心其实就是把get set函数主体放在下面了 
            object IEnumerator.Current => Current;
            private Node<Item> CurrentNode { get; set; }
            private Node<Item> First { get; set; }

            public Item Current
            {
                get
                {
                    if (CurrentNode == null) throw new InvalidOperationException();
                    return CurrentNode.item;
                }
            }

            public StackIEnumerator(LinkedStack<Item> stack)
            {
                First = stack.first;
            }

            public bool MoveNext()
            {
                Node<Item> cur = CurrentNode;
                if (CurrentNode == null)
                {
                    CurrentNode = First;
                }
                else
                {
                    CurrentNode = CurrentNode.next;
                }
                return CurrentNode != null;
            }

            public void Reset()
            {
                CurrentNode = First;
                
            }
        }
    }

}
