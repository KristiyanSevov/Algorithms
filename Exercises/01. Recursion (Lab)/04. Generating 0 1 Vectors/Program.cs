using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Generating_0_1_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string result = String.Empty;
            GenerateVectors(result, n);
            //int[] arr = new int[n];
            //GenerateVectorArrays(arr, 0);
        }

        private static void GenerateVectors(string result, int n)
        {
            if (n == 0)
            {
                Console.WriteLine(result);
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                GenerateVectors(result + i, n - 1);
            }
        }

        //another option
        private static void GenerateVectorArrays(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(String.Join("", arr));
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                GenerateVectorArrays(arr, index + 1);
            }
        }
    }
}
