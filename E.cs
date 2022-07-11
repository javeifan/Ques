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
            int[] array = getRandomNums(n, 1, 100, true);
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
            for (int i = 0; i < n - 1; i++)
            {
                List<int[]> lista = new List<int[]>();
                list.Add(lista);
                int[] startArray = new int[1];
                startArray[0] = nums[i];
                recursiveLISBFS(1, nums, startArray, lista);
            }
            return null;
        }

        //the list contains 
        public void recursiveLISBFS(int length, int[] origNums, int[] increasingSubse, List<int[]> list)
        {
            int length1 = origNums.Length;
            int length2 = increasingSubse.Length;
            int index = getIndexByBFS(increasingSubse[length2], origNums);

            if (index + 1 == length1)
            {
                list.Add(increasingSubse);
                return;
            }

            for (int i = index + 1; i < length1; i++)
            {
                if (increasingSubse[length2] < origNums[i])
                {



                }
            }
            return;
        }

        public int[] arrayAdd(int[] origArray, int newNum)
        {
            int[] expandedArray = new int[origArray.Length + 1];
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
        public int[] getRandomNums(int length, int lowerBound, int upperBound, bool isDistinct)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            int[] array = new int[length];
            if (isDistinct)
            {
                List<int> originNumsList = new List<int>();
                for (int i = 0; i < upperBound - lowerBound + 1; i++)
                {
                    originNumsList.Add(lowerBound + i);
                }
                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(0, originNumsList.Count);
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

        public void showArray(int[] array)
        {

            Console.Write("[");
            for (int i = 0; i < array.Length - 1; i++)
            {

                Console.Write(array[i] + ",");
            }
            Console.Write(array[array.Length - 1] + "]");


        }
























        //键盘行
        public String[] Q500()
        {
            string[] words1 = { "Hello", "Alaska", "Dad", "Peace" };
            string[] words2 = { "omk" };
            string[] words3 = { "adsdf", "sfd" };
            string[] words4 = { "wqweqwr", "asdfw", "qwedsf", "xcvxcv" };

            string[] lines = { "qwertyuiop", "asdfghjkl", "zxcvbnm" };

            for (int i = 0; i < 3; i++)
            {

            }

            return null;
        }

        //键盘行内部函数
        public String[] Q500F1(string[] lines, string[] words)
        {
            int lineNum = 0;
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
                        if (wordsCharArray[0] == (lines[j])[k])
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
                        if (wordsCharArray[j] == lines[lineNum][k])
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        break;
                    }
                }
            }
            return null;
        }


        //sum of two nums
        //in this solution , time Cplxt = O(n^2)
        public int[] Q1TwoSum1(int[] nums, int target)
        {
            int[] indices = new int[2];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
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
        public int[] Q1TwoSum2(int[] nums, int target)
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

        //300.最长递增子序列
        //Problem1
        public static int LengthOfLongestIncreasingSubstring1(int[] nums)//Brute force
        {
            int max = 1;
            Dictionary<int, int> dic = new Dictionary<int, int>();//空间换时间
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, SubRoutine1OfProblem1(nums, i, dic));
            }
            return max;
        }

        //A recursive routine. Return the max Length of nums[Index]
        //这个过程只是描述了以Index开头的最长递增子序列 以Index开头的最长递增子序列未必是全局最长递增子序列
        //递归是有调用开销的 所以这个很慢 很正常
        //
        public static int SubRoutine1OfProblem1(int[] nums, int index, Dictionary<int, int> dic)//the index indicates which number it is processing.
        {
            int length = nums.Length;// I think you shouldn't concern about little differne of memory which would affect your results,achievement.
            int maxLengthOfIndex = 0;
            int maxLengthOfI = 0;
            int maxLength = 0;
            //1.Critical cases..
            if (dic.ContainsKey(index))
            {
                return dic[index];
            }
            if (index == length - 1)
            {
                return 1;
            }
            //2.Main function
            for (int i = index + 1; i < length; i++)//Just to descirbe what you want to do step by step exactly. Let's demosntrate the procedure here.
            {
                if (nums[i] > nums[index])//不一定从0号元素开始的才是最长递增子序列
                {
                    maxLengthOfI = SubRoutine1OfProblem1(nums, i, dic);//以该元素开头的子数组的最长长度，计算过程和原来一样
                    maxLengthOfIndex = Math.Max(maxLengthOfI, maxLengthOfIndex);//取所有以比num[index]大的数字开头的子数组中最长的子序列 You need a local variable to record the max.
                }
            }
            maxLength = 1 + maxLengthOfIndex;//最长长度加上本身即可
            dic.Add(index, maxLength);
            return maxLength;
        }

        //Problem1
        public static int SubRoutine2OfProblem1(int[] nums, int index)
        {
            int length = nums.Length;
            int maxLength = 1;
            if (index == nums.Length - 1)
            {
                return 1;
            }
            for (int i = index + 1; i < length; i++)
            {
                if (nums[i] > nums[index])
                {
                    maxLength = Math.Max(maxLength, SubRoutine2OfProblem1(nums, index));
                }
            }
            return maxLength;
        }

        //Problem1
        //循环算法就快的多
        public static int LengthOfLongestIncreasingSubstring2(int[] nums)//由于前面的结果是依赖后面的结果 所以我们可以倒着来 先计算后面的结果
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int length = nums.Length;
            dic.Add(nums.Length - 1, 1);//Error1 out of bounds
            int max = 1;
            int maxI;
            for (int i = length - 2; i >= 0; i--)//Error2 你手写时 在这里声明赋值的时候 把
            {
                maxI = 1;//Error3 忘记重置maxI
                for (int j = i + 1; j < length; j++) //一定要注意了 这里变量不要写错了
                {
                    if (nums[i] < nums[j])
                    {
                        maxI = Math.Max(maxI, dic[j] + 1);//Error4 j is not present in dic
                    }
                }
                dic.Add(i, maxI);
                max = Math.Max(max, maxI);
            }
            return max;
        }
        //300.最长递增子序列 最快的答案 有空再看 不着急
        public int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;
            int[] d = new int[n + 1];
            int len = 1;
            d[1] = nums[0];
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > d[len])
                    d[++len] = nums[i];
                else
                {
                    int l = 1, r = len, pos = 0;
                    while (l <= r)
                    {
                        int mid = (l + r) >> 1;
                        if (d[mid] < nums[i])
                        {
                            pos = mid;
                            l = mid + 1;
                        }
                        else
                            r = mid - 1;
                    }
                    d[pos + 1] = nums[i];
                }
            }
            return len;
        }
    }
}
