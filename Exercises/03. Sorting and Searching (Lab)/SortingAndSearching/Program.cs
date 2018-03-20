using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] odd = new int[] { 1, 3, 2, 8, -5, 4, 7 };
            //int[] even = new int[] { 1, 3, 2, 8, -5, 4, 7, -3 };
            //MergeSort<int>.Sort(even);
            //Console.WriteLine(String.Join(" ", even));
            ////Console.WriteLine(String.Join(" ", MergeSort<int>.Sort(even)));

            //QuickSort.Sort<int>(odd);
            //Console.WriteLine(String.Join(" ", odd));

            int[] arr = new int[] { -8, -6, 1, 4, 5, 7, 9 };
            for (int i = -10; i < 11; i++)
            {
                Console.WriteLine(BinarySearch<int>.IndexOf(arr, i));
            }
        }
    }
}
