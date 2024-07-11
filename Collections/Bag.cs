using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    interface Bag<Item>
    {
        public void add(Item item);
        public bool isEmpty();
        public int size();
        
    }
}
