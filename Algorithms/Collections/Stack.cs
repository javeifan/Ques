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
        void push(Item item);//default public in interface
        Item pop();
        bool isEmpty();
        int size();
    }
    class LinkedStack<Item> : Stack<Item>
    {
        private Node<Item> first {get; set;}
        private int N {get; set;}

        public bool isEmpty()
        {
            return first == null;//remember this concise, terse and brief
        }

        public Item pop()
        {
            Node<Item> _first = first;
            first = first.next;
            N--;
            return _first.item;
        }

        public void push(Item item)
        {
            Node<Item> newFirst = new Node<Item>();
            newFirst.item = item;
            newFirst.next = first;
            first = newFirst;
            N++;
        }

        public int size()
        {
            return N;
        }
    }

}
