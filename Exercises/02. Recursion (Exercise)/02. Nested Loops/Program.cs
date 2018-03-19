using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Nested_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            PrintValues(arr, 0);
        }

        private static void PrintValues(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(String.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                PrintValues(arr, index + 1);
            }
        }
    }
}
