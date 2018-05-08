using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Parking_Zones
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Zone> zones = new List<Zone>();
            List<ParkingSpot> spots = new List<ParkingSpot>();
            int numZones = int.Parse(Console.ReadLine());
            for (int i = 0; i < numZones; i++)
            {
                string[] inputs = Console.ReadLine().Split(':');
                string name = inputs[0];
                string[] numbers = inputs[1].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int X1 = int.Parse(numbers[0]);
                int Y2 = int.Parse(numbers[1]);
                int width = int.Parse(numbers[2]);
                int height = int.Parse(numbers[3]);
                decimal price = decimal.Parse(numbers[4]);
                Zone zone = new Zone(name, X1, Y2, width, height, price);
                zones.Add(zone);
            }
            string[] spotInputs = Console.ReadLine().Split(';');
            foreach (var sp in spotInputs)
            {
                int[] coords = sp.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                ParkingSpot spot = new ParkingSpot(coords[0], coords[1]);
                spots.Add(spot);
            }
            string[] targetInputs = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int targetX = int.Parse(targetInputs[0]);
            int targetY = int.Parse(targetInputs[1]);
            int timePerMove = int.Parse(Console.ReadLine());

            ParkingSpot bestSpot = null; 
            string bestZone = null;
            decimal bestPrice = Decimal.MaxValue;
            int bestDistance = -1;
            foreach (var spot in spots)
            {
                int distance = (Math.Abs(targetX - spot.X1) + Math.Abs(targetY - spot.Y1) - 1) * 2;
                int seconds = distance * timePerMove;
                int minutes = (int)Math.Ceiling(seconds / 60.0);

                foreach (var zone in zones)
                {
                    if (zone.IsInZone(spot))
                    {
                        decimal price = zone.Price * minutes;
                        if (price < bestPrice || (price == bestPrice && distance < bestDistance))
                        {
                            bestSpot = spot;
                            bestZone = zone.Name;
                            bestPrice = price;
                            bestDistance = distance;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("Zone Type: {0}; X: {1}; Y: {2}; Price: {3:f2}", 
                bestZone, bestSpot.X1, bestSpot.Y1, bestPrice);
        }
    }

    class ParkingSpot
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public ParkingSpot(int x1, int y1)
        {
            X1 = x1;
            Y1 = y1;
        }
    }

    class Zone
    {
        public string Name { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public decimal Price { get; set; }

        public Zone(string name, int x1, int y1, int width, int height, decimal price)
        {
            Name = name;
            X1 = x1;
            Y2 = y1;
            X2 = x1 + width;
            Y2 = y1 + height;
            Price = price;
        }

        public bool IsInZone(ParkingSpot spot)
        {
            return spot.X1 >= this.X1 && spot.X1 < X2 && spot.Y1 >= this.Y1 && spot.Y1 < this.Y2;
        }
    }
}
