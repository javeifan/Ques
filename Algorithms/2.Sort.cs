using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ques.Tools;
using System.Diagnostics;

namespace Ques.Algorithms
{
    class Sort
    {
        public static void exch<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        #region Test function
        public delegate T[] SortFunction<T>(T[] array);

        public static bool CheckIfSorted(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] < nums[i])
                {
                    Console.WriteLine("defeat");
                    return false;
                }
            }
            TA(nums);
            Console.WriteLine("success");
            return true;
        }

        string SortedTestString = "Sort.SortedTest(Sort.InsertionSort);";

        public static void SortedTest(SortFunction<int> sortFunction)
        {
            for (int i = 0; i < 50; i++)
            {
                int[] nums = MathTool.getRandomInt(-5, 25, 10);
                if (!CheckIfSorted(sortFunction(nums)))
                {
                    Console.WriteLine("Some Problems there");
                }
            }
        }

        

        public static void TA(int[] nums)//traverse array
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }
        public static void TA(List<int> nums)//traverse array
        {
            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }


        public class SortCompare
        {
            string test = "Sort.SortCompare.TimeRandomInputCompare(Sort.ShellSort,Sort.InsertionSort,1000,100);";
            public static double time(SortFunction<int> sortFunction, int[] a)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                sortFunction(a);
                stopwatch.Stop();
                return stopwatch.Elapsed.TotalMilliseconds;
            }

            //The 1st element of double[] is the time sort1 uses, the same goes for the second element.
            public static double[] TimeRandomInputCompare(SortFunction<int> sort1, SortFunction<int> sort2, int N, int T)
            {
                double[] output = new double[2];
                for (int i = 0; i < T; i++)
                {
                   int[] randomInts =  MathTool.getRandomInt(0, N, N);
                    output[0] += time(sort1, randomInts);
                    output[1] += time(sort2, randomInts);
                }
                return output;
            }

            //The 1st element of double[] is the time sort1 uses, the same goes for the second element.
            public static double[] TimeReverseOrderCompare(SortFunction<int> sort1, SortFunction<int> sort2, int N)
            {
                double[] output = new double[2];
                int[] reverseInts = new int[N];
                for (int i = 0; i < N; i++)
                {
                    reverseInts[i] = N - i;
                }
                output[0] += time(sort1, reverseInts);
                output[1] += time(sort2, reverseInts);
                return output;
            }

            public static void SortComparison(SortFunction<int> sort1, SortFunction<int> sort2, int N, int T)
            {
                double[] times = TimeRandomInputCompare(sort1, sort2, N, T);
                Console.Write(sort1.Method.Name + " : ");
                Console.WriteLine(times[0]);
                Console.Write(sort2.Method.Name + " : ");
                Console.WriteLine(times[1]);
            }

            public static void SortComparisonReverseOrder(SortFunction<int> sort1, SortFunction<int> sort2, int N)
            {
                double[] times = TimeReverseOrderCompare(sort1, sort2, N);
                Console.Write(sort1.Method.Name + " : ");
                Console.WriteLine(times[0]);
                Console.Write(sort2.Method.Name + " : ");
                Console.WriteLine(times[1]);
            }
        }
        #endregion


        public class SortExercise
        {
            public static void _218()
            {
                for (int i = 0; i < 10; i++)
                {
                    int[] a = TestInput.GetRandomIntsInRange(2, 5);
                    TA(a);
                    TA(InsertionSort(a));
                }
            }

            public static void _2112()
            {
                for (int i = 1; i < 6; i++)//太大这个机器跑不出来
                {
                    int N = Convert.ToInt32(Math.Pow(10, i));
                    int[] a = TestInput.getRandomInt(0,N,N);
                    int h = 1;
                    double CompareCount = 0;
                    while (h < N) h = 3 * h + 1;
                    while (h > 0)
                    {
                        for (int j = h; j < N; j++)
                        {
                            int pivot = a[j];
                            int k;
                            for (k = j; k >= h && a[k - h] > pivot ; k -= h,CompareCount++)
                            {
                                a[k] = a[k-h];
                            }
                            a[k] = pivot;
                        }
                        h /= 3;
                    }
                    double ratio =  CompareCount / Convert.ToDouble(N);
                    Console.WriteLine("Compare count = " + CompareCount + ", N = " + N);
                    Console.WriteLine("Compare count / N  = " + ratio);
                }
            }

            //出列排序
            //限制条件：只能查看最上面的两张牌，交换最上面的两张牌或者把最上面的一张牌放到牌堆底
            //扑克牌相当于数字1-52，查看相当于比较，交换可以换位置，放到牌堆底可以改变查看的两张牌
            //放到牌堆底的操作 对数组操作很麻烦 所以需要用list
            //需要
            public static void _2114()
            {
                List<int> a = TestInput.GetRandomPokers().ToList();
                for (int i = 0; i < a.Count; i++)
                {
                    //第i轮要比较51 - i次，并且把最终比较的最小的结果，也就是a[0]放到牌堆底
                    for (int j = 0; j < 51 - i; j++)
                    {
                        if (a[0] < a[1]) Exch();
                        Bottom();
                    }
                    //最后要把这张牌放到牌堆底 并且在比较了一轮过后 头部的一部分牌是之前按顺序排好的 要把这部分牌放到牌堆底 不然等会给他们比较出去了
                    for (int k = 0; k < i + 1; k++)
                    {
                        Bottom();
                    }
                }
                TA(a);
                void Exch()//交换牌堆顶的两张牌
                {
                    int top = a[0];
                    a[0] = a[1];
                    a[1] = top;
                }
                void Bottom()//把牌放到牌堆底
                {
                    int top = a[0];
                    a.RemoveAt(0);
                    a.Add(top);
                }
            }
        }

        /* 1. The runtime is independent of the input. O(n^2)
         * 2. Data movement is minimized.
         * 
         * Sort.SortCompare.TimeRandomInputCompare(Sort.InsertionSort, Sort.SelectionSort, 1000, 100) gets 491ms
         */
        public static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j]<array[min])
                    {
                        min = j;
                    }
                }
                exch(array, i, min);
            }
            return array;
        }

        public static IComparable[] SelectionSort<T>(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                for (int j = i+1; j < a.Length-1; j++)
                {
                    if(a[j].CompareTo(min) < 0)
                    {
                        min = j;
                    }
                }
                exch(a,i,min);
            }
            return a;
        }

        /* Averagely a  quicker than selection sort. O(n^2)
         * Sort.SortCompare.TimeRandomInputCompare(Sort.InsertionSort, Sort.SelectionSort, 1000, 100) gets 317ms
         * 对于部分有序 且小规模的数组 选择插入排序
         */
        public static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int pivot = array[i];
                int j = i;
                while ( j >= 1 && pivot < array[j-1] )
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = pivot;
            }
            return array;
        }
        /* For循环版本比while要快不少
         * version in "for i" loop
        */
        public static int[] InsertionSortFor(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int pivot = array[i];
                int j;
                for (j = i; j > 0 && pivot < array[j - 1]; j--)
                {
                    array[j] = array[j - 1];
                }
                array[j] = pivot;
            }
            return array;
        }

        /* O(N^(3/2))
         * 这里的h序列选择(3^k-1)/2
         */
        public static int[] ShellSort(int[] a)
        {
            int N = a.Length;
            int h = 1;
            while (h < N / 3) h = 3 * h + 1;
            while (h >= 1)
            {
                for (int i = h; i < N; i++)
                {
                    int j = i;
                    int pivot = a[i];
                    while ( j >= h && a[j - h] > pivot)
                    {
                        a[j] = a[j - h];
                        j = j - h;
                    }
                    a[j] = pivot;
                }
                h = h / 3;
            }
            return a;
        }

        /*对于希尔排序 for循环和while循环有效率差距
         * 希尔排序的For版本比插入排序的while和for版本都要快一些 数组越大效果越明显
         */
        public static int[] ShellSortFor(int[] a)
        {
            int N = a.Length;
            int h = 1;
            while (h < N / 3) h = 3 * h + 1;
            while (h >= 1)
            {
                for (int i = h; i < N; i++)
                {
                    int j;
                    int pivot = a[i];
                    for (j = i; j >= h && a[j] >= pivot; j -= h)
                    {
                        a[j] = a[j - h];
                    }
                    a[j] = pivot;
                }
                h = h / 3;
            }
            return a;
        }

        public static int[] SortTest(int[] a) 
        {
            int N = a.Length;
            int h = 1;
            while (h < N) h = 3 * h + 1;
            while (h > 0)
            {
                for (int j = h; j < N; j++)
                {
                    int pivot = a[j];
                    int k;
                    for (k = j; k >= h && a[k - h] > pivot; k -= h)
                    {
                        a[k] = a[k - h];
                    }
                    a[k] = pivot;
                }
                h = h / 3;
            }
            return a;
        }

        //显示希尔排序的h数组
        public static void ShowHArray(int[] a, int start, int h)
        {
            int N0 = a.Length / h;
            int N = a.Length / h + 1;//h数组的元素个数
            if (start + h * N0 >= a.Length) N = N - 1;//后面的几个h数组的总长度可能比前面少1
            int[] newA = new int[N];
            for (int i = 0; i < N; i++)
            {
                newA[i] = a[start + i * h];
            }
            TA(newA);
        }
        
    }
}
