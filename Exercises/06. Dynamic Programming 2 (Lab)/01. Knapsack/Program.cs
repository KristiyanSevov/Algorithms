using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Knapsack
{
    class Program
    {
        static int[,] matrix;
        static bool[,] taken;

        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            List<Item> takenItems = new List<Item>();
            int capacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputs = input.Split(' ');
                items.Add(new Item(inputs[0], int.Parse(inputs[1]), int.Parse(inputs[2])));
                input = Console.ReadLine();
            }
            matrix = new int[items.Count + 1, capacity + 1];
            taken = new bool[items.Count + 1, capacity + 1];
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                int itemWeight = items[row - 1].Weight;
                int itemValue = items[row - 1].Value;
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (itemWeight <= col &&
                        matrix[row - 1, col - itemWeight] + itemValue > matrix[row - 1, col])
                    {
                        matrix[row, col] = matrix[row - 1, col - itemWeight] + itemValue;
                        taken[row, col] = true;
                    }
                    else
                    {
                        matrix[row, col] = matrix[row - 1, col];
                    }
                }
            }
            int curRow = matrix.GetLength(0) - 1;
            int curCol = matrix.GetLength(1) - 1;
            while (curRow >= 0 && curCol >= 0)
            {
                if (taken[curRow, curCol])
                {
                    takenItems.Add(items[curRow - 1]);
                    curCol -= items[curRow - 1].Weight;
                }
                curRow--;
            }
            Console.WriteLine("Total Weight: {0}", takenItems.Select(x => x.Weight).Sum());
            Console.WriteLine("Total Value: {0}", takenItems.Select(x => x.Value).Sum());
            foreach (var item in takenItems.OrderBy(x => x.Name))
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }

        public Item(string name, int weight, int value)
        {
            Name = name;
            Value = value;
            Weight = weight;
        }
    }
}
