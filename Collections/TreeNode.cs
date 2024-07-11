using Ques.Tools;
using System;
using System.Collections.Generic;

namespace Ques.Collections
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public List<List<int?>> treeList;

        public TreeNode()
        {
        }
        public TreeNode(int val)
        {
            this.val = val;
        }

        public TreeNode(decimal testCase)
        {
            switch (testCase)
            {
                case 1:
                    {
                        this.val = -10;
                        this.left = new TreeNode(9);
                        this.right = new TreeNode(20);
                        this.right.left = new TreeNode(15);
                        this.right.right = new TreeNode(7);
                        break;
                    }
            }
            

        }

        public virtual bool contains(int val)//this should be override.
        {
            return false;
        }

        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        

        public int CheckHeight(int?[] arr, int index) //check the height of the tree
        {
            int level = 1;
            bool isThisLevel = false;
            while (!isThisLevel)
            {
                if (MathTool.Sum_ProportionalSequence(2, level - 1) < index && MathTool.Sum_ProportionalSequence(2, level) > index)
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
            if (node.left != null) l_H = CheckHeightHelper(node.left);
            if (node.right != null) r_H = CheckHeightHelper(node.right);
            return 1 + Math.Max(l_H, r_H);
        }

        //we have only normal tree style
        public enum TreeStyle
        {
            normal,
            casual
        }

        //this is a intelligent print but not implemented now
        public void PrintTree(TreeStyle style = TreeStyle.normal)
        {
            if (style == TreeStyle.normal)
            {
                int lineNum = Convert.ToInt32(Math.Pow(2, CheckHeight() - 1));
                //this is possible but also hard to implement.
            }
            else if (style == TreeStyle.casual)
            {
                int height = CheckHeight();
                for (int i = 0; i < height; i++)
                {
                    string line = "";
                    for (int j = 0; j < treeList[i].Count; j++)
                    {
                        line += wrap(treeList[i][j],Wrapper.brackets);
                        line += " ";
                    }
                    Console.WriteLine(line);
                }
            }else// this is my impossible idea
            {
                int height = this.treeList.Count - 1;

                //max count of the last level 
                int maxCount = Convert.ToInt32(Math.Pow(2, this.treeList.Count - 1));

                //write level 1
                int totalLineSpace = maxCount * 3 + (maxCount - 1) * 1;
                int numSpacing = 1;
                int padding = 0;
                for (int i = height; i > 0; i++)
                {
                    padding = padding + 2;
                    int levelCount = Convert.ToInt32(Math.Pow(2, i - 1));
                    numSpacing = (totalLineSpace - padding * 2 - levelCount * 3) / (levelCount - 1);
                }
                for (int i = 0; i < height; i++)
                {
                    int levelCount = Convert.ToInt32(Math.Pow(2, i + 1));
                    int paddingNum = totalLineSpace - levelCount * 3;
                }
            }
        }

        enum Wrapper
        {
            brackets
        }

        string wrap(int? num, Wrapper wrapper)
        {
            int digit = 0;
            string tempNum = num != null ? num.Value + "" : "";
            string result = "" + tempNum;
            if (wrapper == Wrapper.brackets)
            {
                result = "[" + tempNum + "]";
            }
            else
            {
                while (num != 0)
                {
                    digit++;
                    num /= num;
                }
                if (digit == 1)
                {
                    result = " " + num + " ";
                }
                else if (digit == 2)
                {
                    result = " " + num;
                }
            }
            return result;
        }

        void unfold() //unfold this tree into a list
        {
            List<int[]> list = new List<int[]>();
            void sub(int level ,int order,TreeNode node)
            {
                //initialize array of level I
                if (list[level - 1] == null) list[level - 1] = new int[Convert.ToInt32(Math.Pow(2, level - 1))];
                
                //fill in the position
                int i = order - Convert.ToInt32(Math.Pow(2, level - 1));
                list[level - 1][i - 1] = 1;

                //Traverse child-nodes
                if (node.left != null) sub(level+1, order*2, node.left);
                if (node.right != null) sub(level + 1, order * 2 + 1, node.right);
            }
            sub(1,1,this);
            //transfer to tree list.
            
        }

        public TreeNode restore(int[] array)//not complete
        {
            TreeNode[] treeNodes = new TreeNode[array.Length];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                TreeNode treeNode = new TreeNode(array[i]);
                int leftInd = 2 * i + 1;
                int rightInd = leftInd + 1;
                if (leftInd <= array.Length) treeNode.left = treeNodes[1];
            }
            return treeNodes[0];
        }

        public int[] toList(TreeNode node)//turn a binary tree into 1D array
        {
           return new int[1];
        }

        public void preOrder_ToList(TreeNode node,List<int> list)
        {
            if (node == null) return;
            list.Add(node.val);
        }
    }
}
