using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    interface Stack<Item>
    {
        public void push(Item item);
        public Item pop();
    }
}
