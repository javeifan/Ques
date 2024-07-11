using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    class Dic<TKey,TValue>
    {
        public struct Entry
        {
            public TKey key;
            public TValue value;
            public int next;
        }

        private int EntriesCount = 0;
        public int[] Bucket = new int[3];
        public Entry[] Entries = new Entry[3];

        public Dic()
        {
           
        }

        public void Enlarge()
        {

        }
    }
}
