using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Algorithms.Collections
{
    class Node<Item>
    {
        //This is for linked list.
        public Item item { get; set; }
        public Node<Item> next { get; set; }

        public Node(Item item)
        {
            this.item = item;
        }
        public Node()
        {
        }

        public static Node<int> GetTestLinkedList(int id)
        {
            switch (id)
            {
                case 1:
                    {
                        Node<int> n1 = new Node<int>(1);
                        Node<int> n2 = new Node<int>(2);
                        Node<int> n3 = new Node<int>(3);
                        Node<int> n4 = new Node<int>(4);
                        Node<int> n5 = new Node<int>(5);
                        Node<int> n6 = new Node<int>(6);
                        n1.next = n2;
                        n2.next = n3;
                        n3.next = n4;
                        n4.next = n5;
                        n5.next = n6;
                        return n1;
                    }
                case 2:
                    {
                        Node<int> n1 = new Node<int>(1);
                        Node<int> n2 = new Node<int>(2);
                        n1.next = n2;                    
                        return n1;
                    }

            }
            return new Node<int>(1);
        }

        public override string ToString()
        {
            return this.item.ToString();
        }

        public void showLinkedList()
        {
            Node<Item> first = this;
            while (first != null)
            {
                Console.Write(first+" ");
                first = first.next;
            }
        }


    }

    public class LinkedList
    {

    }
}
