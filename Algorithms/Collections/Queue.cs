using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Algorithms.Collections
{
    interface Queue
    {
        
    }
    class LinkedQueue<Item>
    {
        Node<Item> first { get;  set; }
        Node<Item> last { get; set; }
        int N { get; set; }

        public void Enqueue(Item item)
        {
            Node<Item> oldlast = last;
            Node<Item> newNode = new Node<Item>(item);
            last = newNode;
            if (oldlast == null) first = last;
            else oldlast.next = last;
            N++;
        }
        public Item Dequeue()
        {
            if (N == 0)
            {
                throw new Exception("The queue is empty");
                return default(Item);
            }
            Node<Item> temp = new Node<Item>();
            first = first.next;
            N--;
            return temp.item;
        }
        public bool IsEmpty()
        {
            return first == null;
        }
    }
}
