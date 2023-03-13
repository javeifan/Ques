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
            List<int> list_max = new List<int>();
            _1026_sub_1(0, 0, list_max, root);
            return list_max.Max();
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
            max = Math.Max(max, max_l);
            max = Math.Max(max, max_r);
            inherit.Remove(node.val);
            return max;
        }
        public static int _1026_1(TreeNode root)
        {
            List<int> list_max = new List<int>();
            _1026_sub_1(root.val, root.val, list_max, root);
            return list_max.Max();
        }

        public static void _1026_sub_1(int min, int max, List<int> maxlist, TreeNode node)
        {
            if (node == null) return;
            max = Math.Max(max, node.val);
            min = Math.Min(min, node.val);
            if (node.left == null && node.right == null)
            {
                maxlist.Add(max - min);
            }
            _1026_sub_1(min, max, maxlist, node.left);
            _1026_sub_1(min, max, maxlist, node.right);
        }

        //this is called Bottom-up 
        public static int _1026_2(TreeNode root)
        {
            int diff = 0;
            int[] sub(TreeNode node)
            {
                List<int> vals = new List<int>();
                vals.Add(node.val);
                if (node.left != null)
                    vals.AddRange(sub(node.left));
                if (node.left != null)
                    vals.AddRange(sub(node.right));
                int min = vals.Min();
                int max = vals.Max();
                diff = Math.Max(Math.Max(diff, Math.Abs(node.val - max)), Math.Abs(node.val - min));
                return new int[] { min, max };
            }
            sub(root);
            return diff;
        }
        #endregion
    }
}
