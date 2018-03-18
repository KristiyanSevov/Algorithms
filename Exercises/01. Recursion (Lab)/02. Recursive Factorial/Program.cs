using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(FindFactorial(num));
        }

        private static long FindFactorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            return num * FindFactorial(num - 1);
        }
    }
}
