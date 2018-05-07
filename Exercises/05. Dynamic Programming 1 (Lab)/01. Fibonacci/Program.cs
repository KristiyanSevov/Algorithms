using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 1;
            int b = 1;
            for (int i = 1; i < n; i++)
            {
                int temp = b;
                b = a + b;
                a = temp;
            }
            Console.WriteLine(a);
        }
    }
}
