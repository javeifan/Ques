using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Algorithms
{
    class Search
    {
        public static int binarySearch(int[] array,int target)
        {
            int left = 0;
            int right = array.Length - 1;
            int mid;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (target == array[mid]) return mid;
                if (target < array[mid]) right = mid - 1;
                if (target > array[mid]) left = mid + 1;
            }
            return -1;
        }
    }
}
