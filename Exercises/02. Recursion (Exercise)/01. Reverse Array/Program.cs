using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ');
            PrintReverse(arr, 0);
        }

        private static void PrintReverse(string[] arr, int index)
        {
            if (index == arr.Length)
            {
                return;
            }
            PrintReverse(arr, index + 1);
            Console.Write(arr[index] + " ");
        }
    }
}
