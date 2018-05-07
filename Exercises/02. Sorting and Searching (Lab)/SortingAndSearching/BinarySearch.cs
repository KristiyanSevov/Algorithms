using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    class BinarySearch<T> where T : IComparable<T>
    {
        public static int IndexOf(T[] arr, T key)
        {
            //return Search(arr, key, 0, arr.Length - 1);
            int lo = 0;
            int hi = arr.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (arr[mid].CompareTo(key) < 0)
                {
                    lo = mid + 1;
                }
                else if (arr[mid].CompareTo(key) > 0)
                {
                    hi = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        //private static int Search(T[] arr, T key, int lo, int hi)
        //{
        //    int mid = lo + (hi - lo) / 2;
        //    if (lo > hi)
        //    {
        //        return -1;
        //    }
        //    if (arr[mid].CompareTo(key) < 0)
        //    {
        //        return Search(arr, key, mid + 1, hi);
        //    }
        //    else if (arr[mid].CompareTo(key) > 0)
        //    {
        //        return Search(arr, key, lo, mid - 1);
        //    }
        //    else
        //    {
        //        return mid;
        //    }
        //}
    }
}
