using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    interface Queue<Item>
    {
        public void enqueue(Item item);
        public Item dequeue();
        public bool isEmpty();
        public int size();
    }
}
