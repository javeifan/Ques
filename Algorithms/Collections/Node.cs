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
    }
}
