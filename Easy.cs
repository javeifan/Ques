using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ques
{
    class Easy
    {
        //键盘行
        public String[] Q500()
        {
            string[] words1 = { "Hello", "Alaska", "Dad", "Peace" };
            string[] words2 = { "omk" };
            string[] words3 = { "adsdf", "sfd" };
            string[] words4 = { "wqweqwr","asdfw","qwedsf","xcvxcv"};

            string[] lines ={"qwertyuiop", "asdfghjkl", "zxcvbnm"};

            for (int i = 0; i < 3; i++)
            {

            }

            return null;
        }

        //键盘行内部函数
        public String[] Q500F1(string[] lines,string[] words)
        {
            int lineNum=0;
            string[] res = { };
            for (int i = 0; i < words.Length; i++)
            {
                char[] wordsCharArray = words[i].ToCharArray();
                //1.首先确定它首字母在哪一行
                //由于这里的输入 题目没有说会不会有其他字母 所以这里不用考虑
                for (int j = 0; j < lines.Length; j++)
                {
                    for (int k = 0; k < lines[j].Length; k++)
                    {
                        if (wordsCharArray[0]==(lines[j])[k])
                        {
                            lineNum = j;
                        }
                    }
                }
                //2.后面字母如果不在这一行 就直接放弃
                for (int j = 0; j < wordsCharArray.Length; j++)
                {
                    bool flag = false;
                    for (int k = 0; k < lines[lineNum].Length; k++)
                    {
                        //如果
                        if (wordsCharArray[j]==lines[lineNum][k])
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag==false)
                    {
                        break;
                    }
                }
            }
            return null;
        }


        //sum of two nums
        //in this solution , time Cplxt = O(n^2)
        public int[] Q1TwoSum1(int[] nums,int target)
        {
            int[] indices = new int[2];
            for (int i = 0; i < nums.Length-1; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]+nums[j]==target)
                    {
                        indices[0] = i;
                        indices[1] = j;
                    }
                }
            }
            return indices;
        }


        //!!!there is a key duplicate issue in hashtable , please update this problem
        //sum of two nums
        //in this solution, time Cplxt=O(1)
        public int[] Q1TwoSum2(int[] nums,int target)
        {
            Hashtable ht = new Hashtable();
            int[] resArray = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                //要注意 由于元素是可以重复的 而且我们在这里不能重复使用自身 所以这里要注意不能重复添加 如果重复添加的话
                ht.Add(nums[i], i);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int res = target - nums[i];
                if (ht.Contains(res))
                {
                    resArray[0] = i;
                    resArray[1] = (int)ht[nums[i]];//这里要转型 因为拿出来的是object
                }
            }
            return resArray;
        }

        


    }
}

