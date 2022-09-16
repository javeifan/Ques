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

        /*快速排序 平均运行时间O(nlgn) 
         虽然归并排序运行时间总是O(nlgn) 但快排还是比归并要快
         因为O只是表示数量级 数量级一样但具体时间还受常数影响 
         */
        /*本方法属于原地快排
          这种分治法的计算方法就是计算它的调用栈层数 每一层调用栈的所表示的所有子问题的规模总和=问题输入规模
         */
        public static int[] QuickSort(int[] array)//生序排列
        {
            SubQuickSort(array,0,array.Length-1);
            return array;
        }

        //当你代码语句和别人写的一模一样 但是结果却不一样的时候 你还可以考虑的是 语句顺序 有些语句看起来顺序无所谓 其实是有所谓的
        public static void SubQuickSort(int[] array,int left,int right)//返回pivot的位置 这是一个相当复杂的版本
        {
            if (left > right)//不仅仅是left等于right 因为会有left>right的情况
            {
                return;
            }
            int curLeft = left;
            int curRight = right;
            int pivot = left; //好的快排选枢轴是关键 我这里就懒得随机了
            while (curLeft < curRight)//
            {
                //选的是以左边为基准数 必须要从右边开始 因为在最后的夹逼时 必须要把左边逼到左边当前位置 正好小于pivot才行 因为你最后pivot是跟curLeft交换 Left先往右走是有可能越界的
                while (curLeft < curRight && array[curRight] >= array[pivot]) curRight--;
                while (curLeft < curRight && array[curLeft] <= array[pivot]) curLeft++;
                if(curLeft < curRight)
                {
                    #region exchange curLeft and curRight
                    int temp = array[curLeft];
                    array[curLeft] = array[curRight];
                    array[curRight] = temp;
                    #endregion
                }
            }
            #region exchange curLeft and pivot
            int temp1 = array[curLeft];
            array[curLeft] = array[pivot];
            array[pivot] = temp1;
            #endregion
            SubQuickSort(array, left, curLeft - 1);
            SubQuickSort(array, curLeft + 1,right);
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

        public static void TA_mark(int[] nums,int index)//traverse array and show the marked number
        {
            for (int i = 0; i < index; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.Write("|"+nums[index] + "| ");
            for (int i = index + 1; i < nums.Length; i++)
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
            QuickSort(nums);
            return nums;
        }
    }
}
