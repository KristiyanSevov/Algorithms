using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Travelling_Policeman
{
    class Program
    {
        static int[,] matrix;
        static bool[,] taken;

        static void Main(string[] args)
        {
            List<Street> streets = new List<Street>();
            int fuel = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputs = input.Split(',').Select(x => x.Trim()).ToArray();
                streets.Add(new Street(inputs[0], int.Parse(inputs[1]),
                    int.Parse(inputs[2]), int.Parse(inputs[3])));
                input = Console.ReadLine();
            }

            List<Street> passedStreets = new List<Street>();
           
            matrix = new int[streets.Count + 1, fuel + 1];
            taken = new bool[streets.Count + 1, fuel + 1];
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                int itemWeight = streets[row - 1].Length;
                int itemValue = streets[row - 1].Value;
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
                    passedStreets.Add(streets[curRow - 1]);
                    curCol -= streets[curRow - 1].Length;
                }
                curRow--;
            }
            Console.WriteLine(String.Join(" -> ", passedStreets.Select(x => x.Name).Reverse()));
            Console.WriteLine("Total pokemons caught -> {0}", passedStreets.Select(x => x.Pokemon).Sum());
            Console.WriteLine("Total car damage -> {0}", passedStreets.Select(x => x.Damage).Sum());
            Console.WriteLine("Fuel Left -> {0}", fuel - passedStreets.Select(x => x.Length).Sum());
        }
    }

    class Street
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Pokemon { get; set; }
        public int Length { get; set; }
        public int Value => this.Pokemon * 10 - this.Damage;

        public Street(string name, int damage, int pokemon, int length)
        {
            Name = name;
            Damage = damage;
            Pokemon = pokemon;
            Length = length;
        }
    }
}
