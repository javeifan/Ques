using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Algorithms.Collections
{
    interface Stack<Item>
    {
        //int N { get; set; }//default public in interface
        void Push(Item item);//default public in interface
        Item Pop();
        bool IsEmpty();
        int Size();
    }
    class LinkedStack<Item> : Stack<Item>
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

        public int Size()
        {
            return N;
        }
    }

}
