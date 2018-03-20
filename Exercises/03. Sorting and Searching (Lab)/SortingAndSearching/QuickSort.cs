using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    class QuickSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return;
            }
            int pivot = Partition(arr, lo, hi);
            Sort(arr, lo, pivot - 1);
            Sort(arr, pivot + 1, hi);
        }

        private static int Partition<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            T pivotElement = arr[lo]; //pick the first element as pivot, not optimal but simpler
            int i = lo + 1;
            int j = hi;
            while (true)
            {
                while (arr[i].CompareTo(pivotElement) < 0) //make i point to the first bigger
                {
                    if (i == hi)
                    {
                        break;
                    }
                    i++;
                }
                while (arr[j].CompareTo(pivotElement) >= 0) //make j point to the last smaller
                {
                    if (j == lo)
                    {
                        break;
                    }
                    j--;
                }
                if (i >= j) //doesn't make sense to swap anymore
                {
                    break;
                }
                Swap(arr, i, j);
            }
            Swap(arr, lo, j); //swap pivot element with the last smaller (j)
            return j;
        }

        private static void Swap<T>(T[] arr, int i, int j) where T : IComparable<T>
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
