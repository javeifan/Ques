﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ques.Tools;

namespace Ques.Collections
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int? val)
        {
            this.val = val.Value;
        }

        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public TreeNode(int?[] array)//convert it into TreeNode
        {
            this.val = array[0].Value;
            List<List<int?>> treeList_2d = new List<List<int?>>();
            treeList_2d.Add(new List<int?>());
            int curLevel = 1;
            for (int i = 0; i < array.Length; i++)
            {
                int num_curLevel = Convert.ToInt32(Math.Pow(2, curLevel - 1));
                if (treeList_2d[curLevel - 1].Count < Math.Pow(2,curLevel - 1))
                {
                    Dictionary<int, int> dic = CheckNullToFill(curLevel);
                    int index = treeList_2d[curLevel - 1].Count;
                    while (dic.ContainsKey(index))
                    {
                        for (int j = 0; j < dic[index]; j++)
                        {
                            treeList_2d[curLevel].Add(null);
                        }
                    }
                    treeList_2d[curLevel].Add(array[i]);
                }
                else
                {
                    curLevel++;
                    treeList_2d.Add(new List<int?>());
                }
            }

            //Convert 2d treeNode into 


            

            this.left = TreeNodeHelper(array, 1);
            this.right = TreeNodeHelper(array, 2);

            //It's good If you can use BFS to add elements in sequence
            //which means the value index of this node and next node are only 1 difference
            //But if you use DFS , it's also easy to find the numerical relationship between this node and its sub-nodes.
            TreeNode TreeNodeHelper(int?[] arr, int index)
            {
                if (index >= arr.Length || arr[index] == null) return null;
                TreeNode node = new TreeNode(arr[index]);
                // indexSon1 = indexFather * 2 : this is the numerical relationship between the value index of an node and that of its sub-nodes
                node.left = TreeNodeHelper(arr, 2 * index + 1);
                node.right = TreeNodeHelper(arr, 2 * index + 2);
                return node;
            }


            //this dic indicates in this level, we should populate m nulls from which index n
            Dictionary<int, int> CheckNullToFill(int level)
            {
                Dictionary<int, int> dic = new Dictionary<int, int>();
                for (int i = 2; i < level; i++)
                {
                    for (int j = 0; j < treeList_2d[i - 1].Count; j++)
                    {
                        if (treeList_2d[i - 1][j] == null)
                        {
                            dic.Add(j * 2, 2);
                        }
                    }
                }
                return dic;
            }
        }

        

        public int CheckHeight(int?[] arr, int index) //check the height of the tree
        {
            int level = 1;
            bool isThisLevel = false;
            while (!isThisLevel)
            {
                if (MathTool.Sum_ProportionalSequence(2,level - 1) < index && MathTool.Sum_ProportionalSequence(2, level) > index)
                {
                    isThisLevel = true;
                }
                level++;
            }
            return level;
        }

        public int CheckHeight() //check the height of the tree
        {
            return CheckHeightHelper(this);
        }

        public int CheckHeightHelper(TreeNode node)
        {
            if (node.left == null && node.right == null) return 1;
            int l_H = 0, r_H = 0;
            if(node.left != null) l_H = CheckHeightHelper(node.left);
            if (node.right != null) r_H = CheckHeightHelper(node.right);
            return 1 + Math.Max(l_H,r_H);
        }
    }
}
