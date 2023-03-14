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
            List<List<int?>> _2dTreeList = new List<List<int?>>();
            _2dTreeList.Add(new List<int?>());
            int curLevel = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (_2dTreeList[curLevel - 1].Count >= Math.Pow(2, curLevel - 1))
                {
                    curLevel++;
                    _2dTreeList.Add(new List<int?>());
                }

                if (curLevel == 4)
                {
                    int a = 0;
                }

                Dictionary<int, int> dic = CheckNullToFill(curLevel);
                int index = _2dTreeList[curLevel - 1].Count;
                while (dic.ContainsKey(index))
                {
                    int tempI = index;
                    for (int j = 0; j < dic[tempI]; j++)
                    {
                        _2dTreeList[curLevel - 1].Add(null);
                        index++;
                    }
                }
                _2dTreeList[curLevel - 1].Add(array[i]);
            }
            this.treeList = _2dTreeList;

            //Convert 2d treeNode into 
            List<int?> templist = new List<int?>();
            for (int i = 0; i < _2dTreeList.Count; i++)
            {
                templist.AddRange(_2dTreeList[i]);
            }
            array = templist.ToArray();

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
                int index = level - 2;
                if (index < 0) return dic;
                for (int j = 0; j < _2dTreeList[index].Count; j++)
                {
                    if (_2dTreeList[index][j] == null)
                    {
                        dic.Add(j * 2, 2);
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
    }
}
