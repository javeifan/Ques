using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ques.Collections;

namespace Ques
{
    class M
    {
        #region 1026 Maximum difference between Node and Ancestor
        public static int _1026(TreeNode root)
        {
            return _1026_sub(new List<int>(),root);
        }
        public static int _1026_sub(List<int> inherit, TreeNode node)
        {
            int max = 0;
            if (node == null) return max;
            inherit.Add(node.val);
            int max_l = _1026_sub(inherit, node.left);
            int max_r = _1026_sub(inherit, node.right);
            if (node.left == null && node.right == null)
            {
                max = inherit.Max() - inherit.Min();
            }
            max = Math.Max(max,max_l);
            max = Math.Max(max,max_r);
            return max;
        }
        #endregion
    }
}
