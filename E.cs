using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using Ques.Collections;


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

        public StringBuilder GetRepeatedString(string unit, int times)
        {
            StringBuilder res = new StringBuilder(unit, times + 1);
            for (int i = 0; i < times - 1; i++)
            {
                res.Append(unit);
            }
            return res;
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
                int mid = low + (high - low) / 2;
                if (mid * mid <= x)
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
                if (x / mid > mid) // 等价于 mid*mid <= x
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

        //这个牛顿迭代最快能达到97%的水平
        public static int SqrtXNewton(int x)//牛顿迭代
        {
            //可以用递归做 但估计效果不好
            if (x < 2)
            {
                return x;
            }
            int i = x / 2;//choose a close
            double res = (i + x / i) / 2;
            while (i != (int)res)
            {
                i = (int)res;
                res = (res + x * 1.0 / res) / 2;//不要忘记你i和x都是int不转型的话 是算不出来
                Console.WriteLine("i=" + i);
                Console.WriteLine("res=" + res);
                Thread.Sleep(1000);
            }
            return i;
        }

        //迭代的我就不看了 没有特别的必要 那我直接就不看了
        //一会速度45% 内存99% 一会速度99% 内存6.5%. 这个就随它去吧 反正不要在意太多这种东西就行
        public static ListNode ReverseList(ListNode node)
        {
            ListNode prev = node;// 该被遍历到的元素的下一个元素(原本的next元素)
            ListNode next = null;// 需要一个变量来保存这个被断掉的链子反方向的这个指针 因为找不到 找不回去了
            //视频中再指定了一个curr = node 其实没有必要 
            while (node != null)
            {
                prev = node.next;//1.保存原来顺序的 next 元素
                node.next = next;//2.让现指针指向元素指向在上一层循环中设定的next(也就是它原来顺序的上一个元素) 其实也就是在断链的同时换了链的方向
                next = node;//3.让next指向当前元素
                node = prev;//4.让当前元素前进 
            }
            return next;
        }

        //三个数的最大乘积 并输出这个乘积 默认乘积不会越界
        //考察: 线性扫描
        //思路：可以对输入进行分类 然后根据分类 求每一类的最优解 那么全集的最优解也就是算法的并集了
        //分类有以下几种：
        //1.全正数：找最大的三个数就行了
        //2.全负数：也是找最大的三个数就行了(这里的大不是绝对值大 是本身大)
        //3.有正有负：a.要么找三个最大的正数 b.要么找两个最大的负数 一个最大的正数
        public static int MaximumProduct(int[] nums)
        {

            //不要在意内存的消耗 反正基本上用不完
            return 0;
        }
        //返回array是1.全正 2.全负 3.有正有负且正正数量大于等于3 4.有正有负 正数量小于3 
        public static int CheckArrayNature(int[] nums)
        {
            return 1;
        }

        #region Palindrome linkedList
        //要求O(n)时间和O(1)空间
        //直接在反转链表基础上加个判断就行了、
        //这个极差还是挺大的 快能快到90% 慢也能慢到25%
        public static bool IsPalindrome(ListNode head)
        {
            int length = getLinkedListLength(head);
            int i = 0;
            ListNode newHead = null;
            ListNode nextNode = head;
            while (i < length / 2)
            {
                nextNode = head.next;
                head.next = newHead;
                newHead = head;
                head = nextNode;
                i++;
            }
            if (length % 2 != 0)//回文数序列不顶是偶数的
            {
                head = head.next;
            }

            while (head != null)
            {
                if (head.val != newHead.val)
                {
                    return false;
                }
                head = head.next;
                newHead = newHead.next;
            }
            return true;
        }

        public static int getLinkedListLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.next;
            }
            return length;
        }
        #endregion

        #region LengthOfLongestSubstring
        public int LengthOfLongestSubstring1(string s)//这是我自己的版本
        {
            //要点：滑动窗口 
            char[] chars = s.ToCharArray();
            int l = s.Length;
            if (l == 0)
            {
                return 0;
            }
            int i = 0;
            int j = 0;
            int max = 0;
            while (i < l && j < l - 1)
            {//要保证不能越界
                for (int k = i; k <= j; k++)
                {
                    if (chars[k] == chars[j + 1])
                    {
                        max = Math.Max(max, j - i + 1);
                        i = k + 1;
                        break;
                    }
                }
                j++;
            }
            return Math.Max(max, j - i + 1);
        }

        public static int lengthOfLongestSubstring(string s)
        {
            //这是labuladong的版本 只是把线性扫描换成了dictionary查找 速度变快 内存开销增加
            //但这样会让滑动速度变慢 综合一下看哪个快吧
            Dictionary<char, int> window = new Dictionary<char, int>();

            int left = 0, right = 0;
            int res = 0; // 记录结果
            while (right < s.Length)
            {
                char c = s[right];
                right++;
                //窗口中c的数量增加1
                window[c]++;
                //如果窗口中c的数量大于1
                while (window[c] > 1)
                {
                    char d = s[left];
                    left++;
                    // 进行窗口内数据的一系列更新
                    window[d]--;
                }
                // 在这里更新答案
                res = Math.Max(res, right - left);
            }
            return res;
        }

        #endregion

        #region CoinChange
        public static int CoinChange1(int[] coins, int amount)
        {
            if (amount == 0) return 0;//这里可以放两个basecase 也可以放三个basecase basecase可以用来改变状态 也可以用来判断边界条件
            if (amount < 0) return -1;
            int min = int.MaxValue;//比大小的小技巧
            foreach (int coin in coins)//这是一个多叉树后序遍历 有些直接碰到base case 就直接跳过了
            {
                int temp = 1 + CoinChange1(coins, amount - coin) + 1;
                min = Math.Min(min, temp);//如果这一轮处理的结果不是-1(+1后是0)的话 不要纳入比较
                Console.WriteLine("coin :  " + coin + " amount : " + (amount) + " min : " + min);
            }
            return min == int.MaxValue ? -1 : min;//如果最后都没有纳入比较的话 直接返回min
        }

        public static int CoinChange2(int[] coins, int amount)//递归是相当慢的 自顶向下 又再次自底向上
        {
            int[] dpArray = new int[amount];
            return CoinChange2DP(coins, amount, dpArray);
        }

        public static int CoinChange2DP(int[] coins, int amount, int[] dp)//递归开销相当的大 而且递归加循环 很容易超时 一定要剪枝
        {
            //1.base case
            if (amount < 0) return -1;
            if (amount == 0) return 0;
            if (dp[amount - 1] != 0) return dp[amount - 1];//包括-1 只有还没有遍历过该节点的情况下 才会是0
            int min = int.MaxValue;
            //2.state change
            foreach (int coin in coins)
            {
                int res = CoinChange2DP(coins, amount - coin, dp);
                if (res == -1) continue;
                min = Math.Min(min, res + 1);
            }
            min = min == int.MaxValue ? -1 : min;
            return dp[amount - 1] = min;
        }


        #endregion

        #region 70.Climbing stairs
        //I wanna use dynamic programming 
        public static int _70_ClimingStairs(int n)
        {
            int l = n > 2 ? n : 2; //length
            int[] result = new int[n];
            //Critical cases this is what you need to do
            result[0] = 1;
            result[1] = 2;
            if (l > 2)
            {
                for (int i = 2; i < l; i++)
                {
                    result[i] = result[i - 2] + result[i - 1];
                }
            }
            return result[n - 1];
        }
        public static int CoinChange3(int[] coins, int amount)//用迭代方式解决 自底向上解决 又快又简单了
        {//自底向上 不是从小往大了加 而是先计算小问题的解 在计算大问题的解
            //从小往大加 如果不用递归 我根本不知道怎么做啊
            int[] dp = new int[amount + 1];
            int i = 1;
            while (i < amount + 1)
            {
                dp[i] = amount + 1;
                foreach (int coin in coins)//你这样一步一步往前走过去 是可以覆盖到全结果的 没覆盖到的结果 就是amount+1 很大 完全不影响判断
                {
                    if (i - coin < 0) continue;//直接无解
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }
                i++;
            }
            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }

        public static int CoinChange4(int[] coins, int amount)//自底向上 剪枝DP法 
        {
            int[] dp = new int[amount + 1];
            return -1;
        }

        public static void CoinChange4DP(int[] coins, int curAmount, int targetAmount, int[] dp)
        {
            //1.base case
            if (curAmount >= targetAmount) return;
        }


        #endregion

        //回溯算法 是纯暴力穷举 一般复杂度都很高
        #region Permute
        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> tracks = new List<IList<int>>();
            BacktrackPermute(new List<int>(), nums, tracks);
            return tracks;
        }
        public static void BacktrackPermute(List<int> current, int[] choices, IList<IList<int>> tracks)
        {
            //1.上来先是停止条件
            if (current.Count == choices.Length)
            {
                tracks.Add(new List<int>(current));
                return;
            }
            //2.开始进行回溯的核心
            for (int i = 0; i < choices.Length; i++)
            {
                if (!current.Contains(choices[i]))
                {
                    current.Add(choices[i]);
                    BacktrackPermute(current, choices, tracks);
                    current.RemoveAt(choices[i]);//这样的回溯相当于一个后序遍历
                }
            }
        }
        #endregion

        #region NQueen
        public static IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> tracks = new List<IList<string>>();
            BacktrackNQueens(n, 0, new List<int>(), tracks);
            return tracks;
        }

        public static void BacktrackNQueens(int n, int row, List<int> current, IList<IList<string>> tracks)
        {
            if (current.Count == n)
            {
                tracks.Add(CreateNewNQueensBoard(current, n));
                return;
            }
            for (int col = 0; col < n; col++)
            {
                current.Add(col);
                if (!isNQueensValid(current))
                {

                }
            }
        }

        public static List<string> CreateNewNQueensBoard(List<int> current, int n)
        {
            List<string> board = new List<string>();

            for (int i = 0; i < current.Count; i++)
            {
                StringBuilder sb = new StringBuilder(n);
                for (int j = 0; j < current[i]; j++)
                {
                    sb.Append(".");
                }
                sb.Append("Q");
                for (int j = current[i] + 1; j < n; j++)
                {
                    sb.Append(".");
                }
                board.Add(sb.ToString());
            }
            return null;
        }

        public static bool isNQueensValid(List<int> currentBoard)//不判断整个板 只判断新增的单行就行
        {
            int count = currentBoard.Count;
            for (int i = 0; i < count; i++)
            {
                if (currentBoard[i] == currentBoard[count])
                {
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region 1672.Richest Customer Wealth
        public static int _1672_1(int[][] accounts)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                for (int j = 1; j < accounts[0].Length; j++)
                {
                    accounts[i][j] += accounts[i][j - 1];
                }
                accounts[i][accounts[0].Length - 1] = Math.Max(accounts[i][accounts[0].Length - 1], accounts[i > 0 ? i - 1 : 0][accounts[0].Length - 1]);
            }
            return accounts[accounts.Length - 1][accounts[0].Length - 1];
        }

        public static int _1672_2(int[][] accounts)
        {
            int max = 0;
            foreach (int[] account in accounts)
            {
                for (int i = 1; i < account.Length; i++)
                {
                    account[i] += account[i - 1];
                }
                max = Math.Max(max, account[account.Length - 1]);
            }
            return max;
        }
        #endregion

        #region 1342
        public static int _1342_bitwise(int num) // use bitwise operator to calculate this
        {
            //when we use operator like & | to perform on binary numbers or bit-level data
            //e.g. bitwise & performs a bitwise AND operation between two operands and return a binary number
            int steps = 0;
            while (num > 0)
            {
                if ((num & 1) == 0)
                {
                    num = num >> 1;
                }
                else
                {
                    num--;
                }
                steps++;
            }
            return steps;
        }
        #endregion

        #region 876 middle of the linked list
        public static ListNode _876(ListNode head)
        {
            ListNode node1 = head;
            ListNode node2 = head;
            int n = 1;
            while (node2.next != null)
            {
                if ((n & 1) == 0) node1 = node1.next;
                node2 = node2.next;
                n++;
            }
            if ((n & 1) == 0) node1 = node1.next;
            return node1;
        }
        public static ListNode _876_1(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();
            int n = 0;
            while (head != null)//there is one less execution here
            {
                list.Add(head);
                head = head.next;
                n++;
            }
            return list[n / 2];
        }
        public static ListNode _876_2(ListNode head)
        {
            ListNode middle = head;
            while (head != null && head.next != null)//there is one less execution here
            {
                middle = middle.next;
                head = head.next.next;//anyway, it won't be out of bound. We don't cared  
            }
            return middle;
        }
        #endregion

        #region 383 Ransom Note
        public static bool _383(string ransomNote, string magazine)
        {
            int match = 0;
            List<char> magaList = new List<char>(magazine.ToCharArray());

            foreach (char n in ransomNote)
            {
                foreach (char m in magaList)
                {
                    if (n == m)
                    {
                        match++;
                        magaList.Remove(m);
                        break;
                    }
                }
            }
            if (match == ransomNote.Length) return true;
            return false;
        }

        public static bool _383_1(string ransomNote, string magazine)
        {
            int match = 0;
            foreach (char n in ransomNote)
            {
                int matchingIndex = magazine.IndexOf(n);
                if (matchingIndex == -1) return false;
                //It is valid when the index onlye exceeds the maximum index by one
                magazine = magazine.Substring(0, matchingIndex) + magazine.Substring(matchingIndex + 1);
                match++;
            }
            if (match == ransomNote.Length) return true;
            return false;
        }

        public static bool _383_2(string ransomNote, string magazine)
        {
            //when it comes to find remember hashmap is a great tool to use.
            Dictionary<char, int> hashMap = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                int value = hashMap.GetValueOrDefault(c, 0);
                if (!hashMap.TryAdd(c, value + 1)) hashMap[c] = value + 1;
            }
            foreach (char c in ransomNote)
            {
                int value = hashMap.GetValueOrDefault(c, 0);
                if (value == 0) return false;
                hashMap[c]--;
            }
            return true;
        }
        #endregion

        #region 744 find smallest letter greater than target
        public static char _744(char[] letters,char target)
        {
            char min_c = 'a';
            int min_v = 27; // d-value difference
            foreach (char c in letters)
            {
                int diff = c - target;
                if ( diff>0 && diff < min_v) {
                    min_c = c;
                    min_v = diff;
                }
                if (diff == 1) return min_c;
            }
            if (min_v == 27) return letters[0];
            return min_c;
        }

        //I have no idea how this can be faster than the binary search one.
        //This includes 
        public static char _744_1(char[] letters, char target)
        {
            HashSet<char> set = new HashSet<char>();
            foreach (char c in letters)
            {
                set.Add(c);
            }
            set.Add(target);
            char[] array = new char[set.Count];
            set.CopyTo(array);
            Array.Sort(array);
            int index = Array.IndexOf(array, target);
            if (index < array.Length - 1)
            {
                return array[index + 1];
            }
            return letters[0];
        }

        //This is based on binary search 
        //Because this is a non-decreasing sequence.
        //This saves much space but is slower.
        public static char _744_2(char[] letters, char target)
        {
            int l = 0, r = letters.Length - 1, m = -1;
            while ( l <= r)
            {
                m = (l + r) / 2;
                if (letters[m] > target)
                {
                    r = m - 1;
                }else// here we standardize (letters[m] < target) and (letters[m] = target) because they have to execute the same statement next 
                {
                    l = m + 1;
                }
                //finally l stops at the first position of the right of target
            }
            if (l >= letters.Length) l = 0; 
            return letters[l];
            //when different statements result to the same output, they can be standardize. 
            //what a good way to standardize output statement!
        }
        #endregion

    }
}
