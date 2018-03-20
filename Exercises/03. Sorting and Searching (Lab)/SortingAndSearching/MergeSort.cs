using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class MergeSort<T> where T : IComparable<T>
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (lo >= hi) //only one element
            {
                return;
            }
            int mid = lo + (hi - lo) / 2;
            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Merge(arr, lo, mid, hi);
        }

        private static void Merge(T[] arr, int lo, int mid, int hi)
        {
            if (arr[mid].CompareTo(arr[mid + 1]) <= 0) //already sorted - highest left < smallest right
            {
                return;
            }
            for (int i = lo; i <= hi; i++) //copy all to aux so we can overwrite in the original
            {
                aux[i] = arr[i];
            }
            int left = lo;
            int right = mid + 1;
            for (int j = lo; j <= hi; j++)
            {
                if (left > mid) //we're done with the left elements
                {
                    arr[j] = aux[right];
                    right++;
                }
                else if (right > hi) //we're done with the right elements
                {
                    arr[j] = aux[left];
                    left++;
                }
                else if (aux[left].CompareTo(aux[right]) <= 0)
                {
                    arr[j] = aux[left];
                    left++;
                }
                else
                {
                    arr[j] = aux[right];
                    right++;
                }
            }
        }

        ////the easy way - not in-place and slower
        //public static T[] Sort(T[] arr)
        //{
        //    if (arr.Length <= 1)
        //    {
        //        return arr;
        //    }
        //    T[] sortedLeft = Sort(arr.Take(arr.Length / 2).ToArray());
        //    T[] sortedRight = Sort(arr.Skip(arr.Length / 2).ToArray());
        //    return Merge(sortedLeft, sortedRight);
        //}

        //private static T[] Merge(T[] left, T[] right)
        //{
        //    T[] result = new T[left.Length + right.Length];
        //    int i = 0;
        //    int j = 0;
        //    int resultIndex = 0;
        //    while (i < left.Length && j < right.Length)
        //    {
        //        if (left[i].CompareTo(right[j]) <= 0)
        //        {
        //            result[resultIndex] = left[i];
        //            i++;
        //        }
        //        else
        //        {
        //            result[resultIndex] = right[j];
        //            j++;
        //        }
        //        resultIndex++;
        //    }
        //    while (i < left.Length)
        //    {
        //        result[resultIndex] = left[i];
        //        i++;
        //        resultIndex++;
        //    }
        //    while (j < right.Length)
        //    {
        //        result[resultIndex] = right[j];
        //        j++;
        //        resultIndex++;
        //    }
        //    return result;
        //}
    }
}
