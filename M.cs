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

        #region 958 check completeness of a Binary tree
        /*input type:
         * 1.true : leaf nodes are as far left and no intermediate nodes are missing
           2.false : leaf nodes are not as far left or intermediate nodes are missing  
        */
        public static bool _958(TreeNode root)
        {
            List<int[]> list = new List<int[]>();
            bool res = true;
            void sub(int level, int order, TreeNode node)
            {
                //initialize array of level I
                if (list.Count < level) list.Add(new int[Convert.ToInt32(Pow(2, level - 1))]);

                //check if this is complete
                if (res == false)return;

                //check if the left one is missing i means the ith element in the level
                //等比数列求和公式 sum geometric series : 2^0+2^1+2^2... =  an - a(n-1)
                int i = Convert.ToInt32(Pow(2, level - 1) - Pow(2, level - 2));
                if (order > Pow(2,level - 1) && list[level - 1][i - 1] == 0)
                {
                    res = false;
                    return;
                }

                //fill in the position
                list[level - 1][i - 1] = 1;

                //Traverse child-nodes
                if (node.left != null) sub(level + 1, order * 2, node.left);
                if (node.right != null) sub(level + 1, order * 2 + 1, node.right);
            }
            int Pow(int baseN, int index)
            {
                return Convert.ToInt32(Math.Pow(baseN,index));
            }
            sub(1, 1, root);
            return true;
        }

        //I suddenly comprehend how to use BFS
        public static bool _958_1(TreeNode root)
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            //find height
            int FH(TreeNode node)//finding the height while traversing nodes
            {
                if (node == null) return 0;
                return Math.Max(FH(node.left),FH(node.right)) + 1;
            }
            int height = FH(root);

            bool isComplete = true;
            //compelte the node list
            void Sub(int level,int order,TreeNode node)
            {
                if (!isComplete) return;
                //if it's interior node and order 
                if (node == null)
                {
                    if (level < height )
                    {
                        isComplete = false;
                        return;
                    }
                }
                if (level == height) // there are cases level is greater than height
                {
                    if (order > 1 && node != null && nodeList.Last() == null)
                    {
                        isComplete = false;
                    }
                    nodeList.Add(node);
                    return;
                }
                Sub(level+1,order * 2 - 1,node.left);
                Sub(level + 1, order * 2, node.right);
            }
            Sub(1,1,root);
            return isComplete;
        }

        public static bool _958_2(TreeNode root)
        {
            //we use BFS here
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count !=  0)
            {
                TreeNode node = queue.Dequeue();
                if (node.left!=null) { }
            }
            void sub(TreeNode node)
            {
                if (node == null) return;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);

            }
            return true;
        }
        #endregion
    }
}
