using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ques
{
    class E
    {

        //longest increasing sequence by dynamic programming
        // input : [10,9,2,5,3,7,101,18]
        // output : [2,3,7,10]
        public int[] lengthOfLISByDP(int[] nums)
        {
            int n = nums.Length;
            int[] array = getRandomNums(n,1,100,true);
            int[] dp = new int[n];

            int cnt = 0;
            int max = array[0];
            for (int i = 0; i < n; i++)
            {
                cnt = 0;
                max = array[i];
                for (int j = 0; j < i; j++)
                {
                    if (max < array[i])
                    {
                        max = array[i];
                        dp[i] = dp[j] + 1;
                    }
                }
            }

            return null;
        }

        public int[] lengthOfLISByBruteForceSearch(int[] nums)
        {
            int n = nums.Length;
            List<List<int[]>> list = new List<List<int[]>>();
            for (int i = 0; i < n-1; i++)
            {
                List<int[]> lista = new List<int[]>();
                list.Add(lista);
                int[] startArray = new int[1];
                startArray[0] = nums[i];
                recursiveLISBFS(1,nums,startArray,lista);
            }
            return null;
        }

        //the list contains 
        public void recursiveLISBFS(int length,int[] origNums,int[] increasingSubse,List<int[]> list)
        {
            int length1 = origNums.Length;
            int length2 = increasingSubse.Length;
            int index = getIndexByBFS(increasingSubse[length2], origNums);

            if (index+1 == length1)
            {
                list.Add(increasingSubse);
                return;
            }

            for (int i = index+1; i < length1; i++)
            {
                if (increasingSubse[length2] < origNums[i])
                {
                  
                    
                    
                }
            }



            return null;
        }

        public int[] arrayAdd(int[] origArray, int newNum)
        {
            int[] expandedArray = new int[origArray.Length+1];
            for (int i = 0; i < origArray.Length; i++)
            {
                expandedArray[i] = origArray[i];
            }
            expandedArray[origArray.Length] = newNum;
            return expandedArray;
        }

        public int getIndexByBFS(int target, int[] nums)
        {
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    index = i;
                }
            }
            return index;
        }



        //lowerBound is open interval and upperBound is close interval
        public int[] getRandomNums(int length,int lowerBound,int upperBound,bool isDistinct)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            int[] array = new int[length];
            if (isDistinct)
            {
                List<int> originNumsList = new List<int>();
                for (int i = 0; i < upperBound-lowerBound+1; i++)
                {
                    originNumsList.Add(lowerBound+i);
                }
                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(0,originNumsList.Count);
                    list.Add(originNumsList[index]);
                    originNumsList.RemoveAt(index);
                }
               
            }

            
            for (int i = 0; i < length; i++)
            {
                array[i] = list[i];
            }


            return array;
            
        }

        public void showArray(int[] array) {

            Console.Write("[");
            for (int i = 0; i < array.Length-1; i++)
            {
                
                Console.Write(array[i]+",");
            }
            Console.Write(array[array.Length-1]+"]");


        }
























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

