using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Towns
{
    class Program
    {
        private static int[] people;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            people = new int[n];
            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int citizens = int.Parse(inputs[0]); //no need for the names
                people[i] = citizens;
            }
            int[] increasing = new int[n];
            increasing[0] = 1;
            FillLISArray(increasing);

            int[] decreasing = new int[n];
            decreasing[0] = 1;
            Array.Reverse(people); //the lazy way
            FillLISArray(decreasing);
            Array.Reverse(decreasing);

            int maxLength = 0;
            for (int i = 0; i < n; i++)
            {
                int length = increasing[i] + decreasing[i];
                if (length > maxLength)
                {
                    maxLength = length;
                }
            }
            Console.WriteLine(maxLength - 1);
        }

        private static void FillLISArray(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int max = 0;
                arr[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (people[i] > people[j] && arr[j] + 1 > max)
                    {
                        arr[i] = arr[j] + 1;
                        max = arr[i];
                    }
                }
            }
        }
    }
}
