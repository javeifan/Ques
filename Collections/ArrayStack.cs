using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    class ArrayStack<Item> : Stack<Item>
    {
        Item[] array;
        int sizeI;
        public bool isEmpty()
        {
            if (sizeI == 0) return true;
            return false;
        }

        public ArrayStack(int size)
        {
            this.array = new Item[size];
        }

        public Item pop()
        {
            Item item = array[--sizeI];
            array[sizeI] = default(Item);
            if (sizeI > 0 && sizeI == array.Length/4) resize(array.Length / 2);
            return array[sizeI --];
        }

        public void push(Item item)
        {
            if (sizeI == array.Length) resize(2 * array.Length);
            array[sizeI++] = item;
        }

        public int size()
        {
            return sizeI;
        }

        public void resize(int newSize)
        {
            
        }
    }
}
