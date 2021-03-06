using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ques
{
    public class E
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

        public static void TA(int[] nums)//traverse array
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }

        //Problem1
        //循环算法就快的多
        public static int LengthOfLongestIncreasingSubstring2(int[] nums)//由于前面的结果是依赖后面的结果 所以我们可以倒着来 先计算后面的结果
        {
            int length = nums.Length;
            int[] dic = new int[length];//我们尝试把字典换成数组 把字典换成数组 速度瞬间提升了N多 直接击败了77%的用户
            dic[length - 1] = 1;//Error1 out of bounds
            int max = 1;
            int maxI;
            for (int i = length - 2; i >= 0; i--)//Error2 单等写成双等 还有 i--
            {
                maxI = 1;//Error3 忘记重置maxI
                for (int j = i + 1; j < length; j++) //一定要注意了 这里变量不要写错了
                {
                    if (nums[i] < nums[j])
                    {
                        maxI = Math.Max(maxI, dic[j] + 1);//Error4 j is not present in dic
                    }
                }
                dic[i] = maxI;
                max = Math.Max(max, maxI);//⑤忘了对所有进行比较
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

        //统计素数个数 暴力
        //count the number of prime numbers smaller than n
        //note : 1 is not a prime number
        public static int CountPrimeNumberBF(int n)
        {
            int count = 0;
            for (int i = 2; i < n + 1; i++)
            {
                count += (IsPrime2(i) ? 1 : 0);
            }
            return count;
        }

        //埃氏筛选法
        //埃筛法处理100000以内的素数 只用了4ms
        public static int CountPrimeNumberErato(int n)
        {
            bool[] isPrime = new bool[n];//false 表示素数 数组也是一种字典
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (!isPrime[i])//只要它是素数 全部用
                {
                    for (int j = 2 * i; j < n; j += i)//这里的2*i还可以进一步优化 因为有很多重复的赋值为true的项
                    {
                        isPrime[j] = true;
                    }
                    count++;
                }
            }
            return count;
        }

        //isPrime v1
        //this is actually 
        //这个速度差距是相当大的 在计算100000以内的素数的时候 就已经到710ms了 而IsPrime2只用了9ms
        private static bool IsPrime1(int n)
        {
            for (int j = 2; j < n; j++)
            {
                if (n % j == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //we found that we can omit some unnecessary calculations
        private static bool IsPrime2(int n)
        {
            //int rootn = Convert.ToInt32(Math.Sqrt(n)); //下面可以不用rootn 直接写成 i*i<n 运行速度估计差不多
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //删除排序数组中的重复项
        //返回删除之后的新长度
        //双指针典型题目
        //双指针的用法很多 但是这个方法里的双指针不是典型意义上的双指针
        public static int removeDupFromSorted(int[] nums)
        {
            //讲道理 上来应该先判断处理边界情况
            List<int> list = new List<int>();
            list.Add(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (list[list.Count - 1] != nums[i])
                {
                    list.Add(nums[i]);
                }
            }
            TA(list.ToArray());
            return list.Count;
        }

        //26.力扣要求不能使用额外空间 所以我们就必须使用真正的双指针了
        //击败77%的用户 这个算法在测试中波动很大 上到148(24%) 下到124(98%)
        public static int removeDupFromSorted1(int[] nums)
        {
            int i;//
            int j = 0;//如果把这里改成1 把后面if那里改成j-1的话 速度会明显下降因为每次判断都要算j-1
            for (i = 1; i < nums.Length; i++)
            {
                if (nums[j] != nums[i])
                {
                    nums[++j] = nums[i];
                }
                //你这里不用再i++了 你前面的for循环有i++
            }
            TA(nums);
            return j + 1;
        }
        //724.寻找数组的中心下标
        public static int PivotIndexBF(int[] nums)
        {
            int i;
            int sum = nums[0];
            for (i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            int sum1 = 0;
            sum -= nums[0];//要么把这个数组补足一下 要么这里就多判断一下 判断次数为length+1次
            if (sum == sum1)
            {
                return 0;
            }
            for (i = 0; i < nums.Length - 1; i++)
            {
                sum -= nums[i + 1];
                sum1 += nums[i];
                if (sum1 == sum)
                {
                    Console.WriteLine("Sum = " + sum);
                    Console.WriteLine("Sum1 = " + sum1);
                    if (sum1 == sum)
                    {
                        return i + 1;
                    }
                }
            }
            return -1;
        }

        //运行速度跟上面那个没差 只不过是计算过程简化了一下 
        public static int PivotIndexBF1(int[] nums)//中间可以用公式优化一下
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            int sum1 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sum1 * 2 + nums[i] == sum)
                {
                    return i;
                }
                sum1 += nums[i];
            }
            return -1;
        }

        //69.x的平方根 的整数部分
        //首先要想到二分法 因为这个区间跟排序好的数组是一样的
        //虽然说计算资源已经不缺了 但是尽量不要用递归 消耗还是大的
        //这个算法在计算大数时居然超时了 因为算平方的时候溢出了 所以要用除法来表达这个关系
        //但是用除法的话 要注意除数不能为0
        public static int SqrtXBin(int x)//二分查找法
        {
            int low = 0;
            int high = x;
            int m = 0;
            while (low <= high) //极限夹逼的二分好非极限夹逼的二分 都研究一下吧
            {
                m = (low + high) / 2;
                if (x / m > m)
                { //因为要取的是整数部分 所以是向下取整 
                    low = m + 1;
                }
                else
                {
                    high = m - 1;
                }
        }

            return m;//结果肯定是不会比high大 比0小的 所以放心返回 
        }

        //课程给出的题解 
        public static int SqrtX1(int x)
        {
            int low = 0;
            int high = x;
            int res = 0;
            while (low <= high)
            {
                int mid = low + (high - low)/ 2;
                if (mid * mid <=x)
                {
                    res = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return res;
        }
        
        //网友给出的 二分查找 非极限夹逼 求方根 不知道为什么会生效 但就是会生效。。
        public static int SqrtXBin1(int x)
        {
            int low = 0;
            int high = x;//在high和low的区间内 永远能确保
            while (high > low + 1)//其实夹逼到相邻的时候就已经有答案了 不需要再做多的运算了
            {
                int mid = (high + low) / 2;
                if ( x/mid > mid ) // 等价于 mid*mid <= x
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }
            return low;
        }
    }
    
}
