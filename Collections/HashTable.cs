using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    //有空给这个HashTable加个迭代器
    class HashTable : IHashTable //这是一个最简单的 hashtable的实现 容量为1024
    {
        public int this[int val] { get { 
                return container[Hash(val)]; 
            }
            set {
                container[Hash(val)] = val;
            }
        }

        private int[] container = new int[1024];

        public HashTable()
        {
        }

        public HashTable(int[] nums)//batch processing number
        {
        }

        public int Hash(int key)//子类或者实现类 应该是必须比基类的访问等级要相等或更严格吧
        {
            return (key * 31 * 31 ) % 1024;
        }

        public void Add(int val)
        {
            container[Hash(val)] = val;
        }
    }
}
