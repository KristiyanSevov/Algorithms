using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sequences = new int[nums.Length];
            int[] parents = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                int largest = 0;
                int largestIndex = -1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j] && sequences[j] > largest)
                    {
                        largest = sequences[j];
                        largestIndex = j;
                    }
                }
                sequences[i] = largest + 1;
                parents[i] = largestIndex;
            }

            int longestSeqIndex = 0;
            int longestSeq = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sequences[i] > longestSeq)
                {
                    longestSeq = sequences[i];
                    longestSeqIndex = i;
                }
            }

            Stack<int> result = new Stack<int>();
            result.Push(nums[longestSeqIndex]);
            int index = longestSeqIndex;
            while (result.Count < longestSeq)
            {
                index = parents[index];
                result.Push(nums[index]);
            }            
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
