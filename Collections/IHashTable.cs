using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    //设计良好的散列表查找性能跟数组相当 增删速度与链表相当

    //C# 属性和字段的区别是啥啊？

    //1.所有的接口成员都是公共的 不能用访问权限修饰符来定义
    //2.接口成员不能包含代码体
    //3.接口不能定义字段成员
    //4.接口成员不能用修饰符static virtual abstract 或 sealed 来定义
    //5.类型定义成员是禁止的
    interface IHashTable//Hash table for int
    {
        //接口虽然不能定义字段 但是可以指定访问块get和set哪一个你能用于该属性
        public int this[int val] { get;set; }
        //实现接口的类必须包含该接口所有成员的实现代码
        //且必须匹配指定的签名(包括指定的get和set块)
        //且必须是公共的
        public int Hash(int key);
        public void Add(int val);
    }
}
