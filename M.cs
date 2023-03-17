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
                List<int> vals = new List<int>();//this makes the list only performs on itself and its child-nodes. 
                vals.Add(node.val);
                if (node.left != null)
                    vals.AddRange(sub(node.left));
                if (node.right != null)
                    vals.AddRange(sub(node.right));
                    int min = vals.Min();
                    int max = vals.Max();
                diff = Math.Max(Math.Max(diff, Math.Abs(node.val - max)), Math.Abs(node.val - min));
                return new int[] { min, max };
            }
            sub(root);
            return diff;
        }

        //this is called top-down
        //pass min and max to child.
        //自顶向下就是在底端计算数据
        //自底向上就是在顶端计算数据
        //note that comments lines affect running time.
        public static int _1026_3(TreeNode root)
        {
            int sub(int max, int min, TreeNode node)
            {
                if (node == null) return max - min;
                max = Math.Max(max, node.val);
                min = Math.Min(min, node.val);

                //you want to calculate when it's a leaf node,
                //but judging whether it is a leaf node is more expensive than direct calculation.
                return Math.Max(sub(max,min,node.right),sub(max,min,node.left)); 
            }
            return sub(root.val,root.val,root);
        }
        #endregion

        #region 
        public static bool _958(TreeNode root)
        {
            List<int[]> list = new List<int[]>();
            void sub(int level, int order, TreeNode node)
            {
                //initialize array of level I
                if (list.Count < level) list.Add(new int[Convert.ToInt32(Math.Pow(2, level - 1))]);

                //fill in the position
                int i = order - Convert.ToInt32(Math.Pow(2, level - 1));
                list[level - 1][i] = 1;

                //Traverse child-nodes
                if (node.left != null) sub(level + 1, order * 2, node.left);
                if (node.right != null) sub(level + 1, order * 2 + 1, node.right);
            }
            sub(1, 1, root);
            //check this 
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (list[i][j] == 0) return false;
                }
            }
            for (int j = 0; j < list[list.Count - 1].Length - 1; j++)
            {
                if (list[list.Count - 1][j] == 0 && list[list.Count - 1][j+1] == 1) return false;
            }
            return true;
        }
        #endregion
    }
}
