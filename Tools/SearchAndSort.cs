using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Tools
{
    public class SearchAndSort
    {
        //----------------标准答案----------------
        //The test is not done already.
        //This is a perfect resolution. 
        public static int[] BubbleSort(int[] nums)//ascending one
        {
            //1. Critical Cases 临界情况
            //For every algorithm first, should concern about critical cases.(临界情况) 
            if (nums == null || nums.Length < 2)
            {
                return nums;
            }
            //2. Main Algorithm 算法主体
            for (int i = 0; i < nums.Length; i++)//the outer layer is the number of rounds compared. 
            {// a rounds contains a series of comparision for adjacent elements
                bool isSorted = true;
                for (int j = 1; j < nums.Length - i; j++)
                {
                    if (nums[j-1] > nums[j])
                    {
                        isSorted = false;
                        int temp = nums[j - 1];
                        nums[j - 1] = nums[j];
                        nums[j] = temp;
                    }
                }
                // if there is no element exchange for a whole round, then this array is sorted.
                if (isSorted) break;
            }
            return nums;
        }

        public static int[] SelectionSort(int[] nums)//still ascending
        {
            //1.Critical cases
            if (nums == null || nums.Length < 2)
            {
                return nums;
            }
            //2.Main algorithm
            for (int i = 0; i < nums.Length-1; i++)
            {
                int maxIndex = 0;
                for (int j = 0; j < nums.Length - i; j++)
                {
                    if (nums[j] > nums[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != nums.Length - i)
                {
                    int temp = nums[maxIndex];
                    nums[maxIndex] = nums[nums.Length - i - 1];
                    nums[nums.Length - i - 1] = temp;
                }
            }
            return nums;
        }

        public static int[] InsertionSort(int[] nums)//ascending
        {
            if (nums == null || nums.Length < 2)
            {
                return nums;
            }
            for (int i = 1; i < nums.Length; i++)//this is the number of rounds
            {
                int j = i;
                int pivot = nums[i];
                while (j > 0 && pivot < nums[j-1])//first should determine if it's out of bounds
                {
                    nums[j] = nums[--j];//这里的计算其实很特别 是先确定式子 再赋值 先确定 nums[j] = nums[j-1] 然后计算右边 赋值给左边
                    //但是尽量别像这样写 因为你不知道他的运算顺序的 j--最好单独写
                }
                nums[j] = pivot;
            }
            return nums;
        }

        public static int BinarySearch(int[] nums,int target)
        {
            //这里要有边界判断
            int h = nums.Length-1;
            int l = 0;
            int m;
            while (h >= l)//这里不同于求方根的整数位 这里是要精确到最终结果的 所以 要对于排序好的数组 每一个都要检查一遍
            {
                m = (h+l) / 2;
                if ( nums[m] == target)
                {
                    return m;
                }
                else if( nums[m] < target)
                {
                    l = m + 1;
                }
                else
                {
                    h = m - 1;
                }
            }
            return -1;
        }

        //----------------辅助工具----------------
        public static void TA(int[] nums)//traverse array
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }

        public static bool CheckIfSorted(int[] nums)
        {
            for (int i = 0; i < nums.Length-1; i++)
            {
                if (nums[i+1] < nums[i])
                {
                    Console.WriteLine("defeat");
                    return false;
                }
            }
            TA(nums);
            Console.WriteLine("success");
            return true;
        }
        public static void SortedTest()
        {
            for (int i = 0; i < 50; i++)
            {
                int[] nums = MathTool.getRandomInt(-5,25,10);
                //put your sort method here to test
                if (!CheckIfSorted(TestSort(nums)))
                {
                    Console.WriteLine("Some Problem there");
                }
            }
        }

        //I would write all my exam code here
        //----------------默写地址----------------

        public static int[] TestSort(int[] nums)//先默写个选择吧
        {
            int length = nums.Length;
            if (nums == null || length < 2)//不要忘了边界条件
            {
                return nums;
            }
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        nums[j] = nums[j] + nums[j + 1];
                        nums[j + 1] = nums[j] - nums[j + 1];
                        nums[j] = nums[j] - nums[j + 1];
                    }
                }
            }
            return nums;
        }
    }
}
