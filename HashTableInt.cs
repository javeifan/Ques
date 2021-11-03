using System;
using System.Collections.Generic;
using System.Text;

namespace Ques
{
    class HashTableInt //以int为例
    {
        //本HashTable是用线性表 + 哈希函数寻址 制成 以int为例
        //由于值本身和索引有一一对应的关系 并且这种关系 既可以从关键字求出地址(此处地址为索引)  也可以从地址求出关键字 所以Array可以用来记录元素的个数
        //但是这要求关键字必须是1-16 或是 总跨度在16之内 否则就会产生哈希冲突 无法还原 
        private int[] Array = new int[16];
        private int Min;  //如果要让地址和关键字能够互相映射 而数值跨度为16 所以必须确定

        //要先指定最小值
        public HashTableInt(int MinNum)
        {
            this.Min = MinNum;
        }

        //先不考虑哈希冲突 以及数组超长度问题
        public void Add(int num)
        {
            Array[Hash(num)]++;
        }

        private int Hash(int a)
        {
            return a % 16;
        }
        
    }
}
