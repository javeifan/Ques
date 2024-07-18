using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Algorithms.Collections
{
    interface Bag
    {
    }
    class LinkedBag<Item> : IEnumerable
    {
        Node<Item> first {get; set; }
        int N;

        public void Add(Item item)
        {
            Node<Item> oldFirst = first;
            Node<Item> newFirst = new Node<Item>(item);
            first = newFirst;
            first.next = oldFirst;
            N++;
        }
        public bool IsEmpty() {
            return first == null; 
        }

        public Node<Item> returnFirst()
        {
            return first;
        }

        public IEnumerator GetEnumerator()
        {
            return new BagIterator(this);
        }

        
        //I haven't tested such.
        public class BagIterator : IEnumerator
        {
            public Object Current { get; set; }
            private Node<Item> OrigFirst {get ;set;}

            //内部类需要通过外部类的实例来访问外部类
            //否则就需要用静态变量
            public BagIterator(LinkedBag<Item> bag)
            {
                Current = bag.first;
            }

            public bool MoveNext()
            {
               Node<Item> node = (Node<Item>)Current;
                Current = node.next;
                return Current == null;
            }

            public void Reset()
            {
                Current = OrigFirst;
            }
        }
    }

}
