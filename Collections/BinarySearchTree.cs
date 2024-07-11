using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    class BinarySearchTree : TreeNode
    {
        public BinarySearchTree(int val)
        {  
            this.val = val;
        }

        public override bool contains(int val)
        {
            if (this == null) return false;
            if (this.val == val) return true;
            if (this.val < val) return this.right.contains(val);

            return false;
        }
    }
}
