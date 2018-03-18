using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Recursive_Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Draw(n);
        }

        private static void Draw(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(new String('*', n));
            Draw(n - 1);
            Console.WriteLine(new String('#', n));
        }
    }
}
