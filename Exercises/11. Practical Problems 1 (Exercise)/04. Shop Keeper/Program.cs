using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Shop_Keeper
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> productSet = new HashSet<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            int[] orders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] indices = new int[3001];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = int.MaxValue;
            }
            for (int i = orders.Length - 1; i >= 0; i--)
            {
                indices[orders[i]] = i;
            }
            SortedSet<int> products = new SortedSet<int>(productSet, Comparer<int>.Create((x, y) =>
            {
                int compare = -indices[x].CompareTo(indices[y]);
                if (compare != 0)
                {
                    return compare;
                }
                else
                {
                    return x.CompareTo(y);
                }
            }));
            if (!productSet.Contains(orders[0]))
            {
                Console.WriteLine("impossible");
                return;
            }
            int swaps = 0;
            for (int i = 0; i < orders.Length; i++)
            {
                if (!productSet.Contains(orders[i]))
                {
                    int item = products.Min;
                    products.Remove(item);
                    products.Add(orders[i]);
                    productSet.Add(orders[i]);
                    productSet.Remove(item);
                    swaps++;
                }
                
                //update index and reorder the element in the set
                products.Remove(orders[i]);
                for (int j = i + 1; j < orders.Length; j++)
                {
                    if (orders[j] == orders[i])
                    {
                        indices[orders[i]] = j;
                        break;
                    }
                }
                if (indices[orders[i]] == i)
                {
                    indices[orders[i]] = int.MaxValue;
                }
                products.Add(orders[i]);
            }
            Console.WriteLine(swaps);
        }
    }
}
