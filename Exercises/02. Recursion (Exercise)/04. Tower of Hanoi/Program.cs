using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tower_of_Hanoi
{
    class Program
    {
        public static int steps = 1;
        public static Stack<int> source = new Stack<int>();
        public static Stack<int> destination = new Stack<int>();
        public static Stack<int> spare = new Stack<int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = n; i > 0; i--)
            {
                source.Push(i);
            }
            PrintStacks();
            MoveDisks(n, source, destination, spare); 
        }
   
        private static void PrintStacks()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }

        private static void MoveDisks(int diskCount, Stack<int> src, Stack<int> dest, Stack<int> sp)
        {
            if (diskCount == 1)
            {
                int moved = src.Pop();
                dest.Push(moved);
                Console.WriteLine("Step #{0}: Moved disk", steps);
                PrintStacks();
                steps++;
                return;
            }
            MoveDisks(diskCount - 1, src, sp, dest);
            MoveDisks(1, src, dest, sp);
            MoveDisks(diskCount - 1, sp, dest, src);
        }
    }
}
